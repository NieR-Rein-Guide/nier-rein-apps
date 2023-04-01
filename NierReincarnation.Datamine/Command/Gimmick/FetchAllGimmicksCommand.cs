using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllGimmicksCommand : AbstractDbQueryCommand<FetchAllGimmicksCommandArg, List<Gimmick>>
{
    public override Task<List<Gimmick>> ExecuteAsync(FetchAllGimmicksCommandArg arg)
    {
        List<Gimmick> gimmicks = new();

        foreach (EntityMGimmickOrnament darkGimmickOrnament in MasterDb.EntityMGimmickOrnamentTable.All.OrderBy(x => x.ChapterId).ThenBy(x => x.SortOrder))
        {
            EntityMGimmick darkGimmick = MasterDb.EntityMGimmickTable.All.FirstOrDefault(x => x.GimmickOrnamentGroupId == darkGimmickOrnament.GimmickOrnamentGroupId);

            if (arg.GimmickTypes?.Length > 0 && !arg.GimmickTypes.Contains(darkGimmick.GimmickType)) continue;

            EntityMGimmickGroup darkGimmickGroup = MasterDb.EntityMGimmickGroupTable.All.FirstOrDefault(x => x.GimmickId == darkGimmick.GimmickId);

            foreach (var darkGimmickSequenceSchedule in MasterDb.EntityMGimmickSequenceScheduleTable.All)
            {
                int sequenceId = darkGimmickSequenceSchedule.FirstGimmickSequenceId;

                do
                {
                    int nextSequenceId = GetNextGimmickSequenceId(sequenceId);
                    EntityMGimmickSequence darkGimmickSequence = MasterDb.EntityMGimmickSequenceTable.All
                        .FirstOrDefault(x => x.GimmickGroupId == darkGimmickGroup.GimmickGroupId && x.GimmickSequenceId == sequenceId);

                    if (darkGimmickSequence != null)
                    {
                        Gimmick gimmick = CreateGimmickModel(darkGimmickOrnament, darkGimmick, darkGimmickSequenceSchedule, darkGimmickSequence);

                        if (gimmick != null)
                        {
                            gimmicks.Add(gimmick);
                        }
                    }

                    sequenceId = nextSequenceId;
                }
                while (sequenceId != 0);
            }
        }

        return Task.FromResult(gimmicks);
    }

    private int GetNextGimmickSequenceId(int gimmickSequenceId)
    {
        EntityMGimmickSequence darkGimmickSequence = MasterDb.EntityMGimmickSequenceTable.All
            .FirstOrDefault(x => x.GimmickSequenceId == gimmickSequenceId);

        if (darkGimmickSequence == null || darkGimmickSequence.NextGimmickSequenceGroupId == 0) return 0;

        EntityMGimmickSequenceGroup darkGimmickSequenceGroup = MasterDb.EntityMGimmickSequenceGroupTable.All.FirstOrDefault(x => x.GimmickSequenceGroupId == darkGimmickSequence.NextGimmickSequenceGroupId);

        return darkGimmickSequenceGroup.GimmickSequenceId;
    }

    private Gimmick CreateGimmickModel(EntityMGimmickOrnament darkGimmickOrnament, EntityMGimmick darkGimmick,
        EntityMGimmickSequenceSchedule darkGimmickSequenceSchedule, EntityMGimmickSequence darkGimmickSequence, Gimmick previousGimmick = null)
    {
        int intervalValue = 0;
        int maxValue = 0;

        if (CalculatorWorldMap.IsIntervalDropItemType(darkGimmick.GimmickType))
        {
            EntityMGimmickInterval gimmickInterval = MasterDb.EntityMGimmickIntervalTable.All.FirstOrDefault(x => x.GimmickId == darkGimmick.GimmickId);
            intervalValue = gimmickInterval.IntervalValue;
            maxValue = gimmickInterval.MaxValue;
        }
        EntityMGimmickSequenceRewardGroup darkGimmickReward = MasterDb.EntityMGimmickSequenceRewardGroupTable.All.FirstOrDefault(x => x.GimmickSequenceRewardGroupId == darkGimmickSequence.GimmickSequenceRewardGroupId);

        Gimmick gimmick = new()
        {
            ChapterId = darkGimmickOrnament.ChapterId,
            GimmickType = darkGimmick.GimmickType,
            FlowType = darkGimmickSequence.FlowType,
            StartDateTimeOffset = darkGimmickSequenceSchedule != null ? CalculatorDateTime.FromUnixTime(darkGimmickSequenceSchedule.StartDatetime) : null,
            EndDateTimeOffset = darkGimmickSequenceSchedule != null ? CalculatorDateTime.FromUnixTime(darkGimmickSequenceSchedule.EndDatetime) : null,
            ProgressStartDateTimeOffset = CalculatorDateTime.FromUnixTime(darkGimmickSequence.ProgressStartDatetime),
            ProgressRequireHour = darkGimmickSequence.ProgressRequireHour,
            IntervalValue = intervalValue,
            MaxValue = maxValue,
            OrnamentCount = darkGimmickOrnament.Count,
            IconDifficultyValue = darkGimmickOrnament.IconDifficultyValue,
            Reward = darkGimmickReward != null
                ? new Reward
                {
                    Name = CalculatorPossession.GetItemName(darkGimmickReward.PossessionType, darkGimmickReward.PossessionId),
                    Count = darkGimmickReward.Count
                }
                : null,
            ClearConditions = GetClearConditions(darkGimmick.ClearEvaluateConditionId)
        };

        if (previousGimmick != null)
        {
            previousGimmick.NextSequenceId = darkGimmickSequence.GimmickSequenceId;
            previousGimmick.NextGimmick = gimmick;
        }

        return gimmick;
    }

    private List<string> GetClearConditions(int clearEvaluateConditionId)
    {
        List<string> conditions = new();

        if (clearEvaluateConditionId == 0) return conditions;

        foreach (EntityMEvaluateConditionValueGroup darkConditionGroup in MasterDb.EntityMEvaluateConditionValueGroupTable.All.Where(x => x.EvaluateConditionValueGroupId == clearEvaluateConditionId))
        {
            EntityMEvaluateCondition darkCondition = MasterDb.EntityMEvaluateConditionTable.All.FirstOrDefault(x => x.EvaluateConditionValueGroupId == darkConditionGroup.EvaluateConditionValueGroupId);
            string conditionStr = string.Empty;

            if (darkCondition.EvaluateConditionFunctionType == EvaluateConditionFunctionType.QUEST_MISSION_CLEAR)
            {
                conditionStr = $"report.mission.name.{darkCondition.NameEvaluateConditionTextId}".Localize();
            }
            else if (darkCondition.EvaluateConditionFunctionType == EvaluateConditionFunctionType.RECURSION)
            {
                conditionStr = $"report.mission.name.{darkConditionGroup.Value}".Localize();
            }
            else if (darkCondition.EvaluateConditionFunctionType == EvaluateConditionFunctionType.MISSION_CLEAR)
            {
                EntityMMission darkMission = MasterDb.EntityMMissionTable.FindByMissionId((int)darkConditionGroup.Value);
                conditionStr = $"mission.name.{darkMission?.NameMissionTextId ?? 0}".Localize();
            }

            if (!string.IsNullOrEmpty(conditionStr) && !conditions.Contains(conditionStr))
            {
                conditions.Add(conditionStr);
            }
        }

        return conditions;
    }
}

public class FetchAllGimmicksCommandArg
{
    public GimmickType[] GimmickTypes { get; init; }
}
