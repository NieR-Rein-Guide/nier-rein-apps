using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchEventQuestsCommand : AbstractDbQueryCommand<FetchEventQuestsCommandArg, List<EventQuest>>
{
    public override Task<List<EventQuest>> ExecuteAsync(FetchEventQuestsCommandArg arg)
    {
        List<EventQuest> eventQuests = new();

        var darkEventQuestChapter = MasterDb.EntityMEventQuestChapterTable.FindByEventQuestChapterId(arg.EventQuestChapterId);

        var darkEventQuestSequenceGroup = MasterDb.EntityMEventQuestSequenceGroupTable.All
            .Where(x => x.EventQuestSequenceGroupId == darkEventQuestChapter.EventQuestSequenceGroupId)
            .FirstOrDefault(x => x.DifficultyType == arg.DifficultyType);

        var darkEventQuestSequences = MasterDb.EntityMEventQuestSequenceTable.All
            .Where(x => x.EventQuestSequenceId == darkEventQuestSequenceGroup.EventQuestSequenceId)
            .OrderBy(x => x.SortOrder)
            .ToList();

        foreach (var darkEventQuestSequence in darkEventQuestSequences)
        {
            var darkQuest = MasterDb.EntityMQuestTable.FindByQuestId(darkEventQuestSequence.QuestId);
            var darkQuestSchedule = MasterDb.EntityMQuestScheduleTable.FindByQuestScheduleId(darkQuest.QuestId);

            eventQuests.Add(new EventQuest
            {
                QuestId = darkQuest.QuestId,
                Name = string.Format(UserInterfaceTextKey.Quest.kQuestNameTextKey, darkQuest.NameQuestTextId).Localize(),
                AttributeType = GetQuestDisplayAttributeType(darkQuest.QuestDisplayAttributeGroupId),
                StartDateTimeOffset = darkQuestSchedule != null ? CalculatorDateTime.FromUnixTime(darkQuestSchedule.StartDatetime) : null,
                EndDateTimeOffset = darkQuestSchedule != null ? CalculatorDateTime.FromUnixTime(darkQuestSchedule.EndDatetime) : null,
                RecommendedForce = darkQuest.RecommendedDeckPower,
                FirstClearRewards = GetQuestFirstClearRewards(darkQuest.QuestFirstClearRewardGroupId),
                PickupRewards = arg.IncludePickupRewards ? GetQuestPickupRewards(darkQuest.QuestPickupRewardGroupId) : new()
            });
        }

        return Task.FromResult(eventQuests);
    }

    private QuestDisplayAttributeType GetQuestDisplayAttributeType(int questDisplayAttributeGroupId)
    {
        var darkQuestAttributes = MasterDb.EntityMQuestDisplayAttributeGroupTable.All
            .Where(x => x.QuestDisplayAttributeGroupId == questDisplayAttributeGroupId)
            .ToList();

        return darkQuestAttributes.Count switch
        {
            1 => darkQuestAttributes[0].QuestDisplayAttributeType,
            0 => QuestDisplayAttributeType.NOTHING,
            5 => QuestDisplayAttributeType.ALL,
            _ => QuestDisplayAttributeType.VARIOUS
        };
    }

    private List<Reward> GetQuestFirstClearRewards(int questFirstClearRewardGroupId)
    {
        List<Reward> rewards = new();

        var darkQuestFirstClearRewardGroups = MasterDb.EntityMQuestFirstClearRewardGroupTable.All
            .Where(x => x.QuestFirstClearRewardType == QuestFirstClearRewardType.NORMAL &&
                x.QuestFirstClearRewardGroupId == questFirstClearRewardGroupId)
            .OrderBy(x => x.SortOrder)
            .ToList();

        foreach (var darkQuestFirstClearRewardGroup in darkQuestFirstClearRewardGroups)
        {
            rewards.Add(new Reward
            {
                Name = CalculatorPossession.GetItemName(darkQuestFirstClearRewardGroup.PossessionType, darkQuestFirstClearRewardGroup.PossessionId),
                Count = darkQuestFirstClearRewardGroup.Count
            });
        }

        return rewards;
    }

    private List<Reward> GetQuestPickupRewards(int questPickupRewardGroupId)
    {
        List<Reward> rewards = new();

        var darkQuestPickupRewardGroups = MasterDb.EntityMQuestPickupRewardGroupTable.All
                .Where(x => x.QuestPickupRewardGroupId == questPickupRewardGroupId)
                .OrderBy(x => x.SortOrder)
                .ToList();

        foreach (var darkQuestPickupRewardGroup in darkQuestPickupRewardGroups)
        {
            var darkBattleDropReward = MasterDb.EntityMBattleDropRewardTable.FindByBattleDropRewardId(darkQuestPickupRewardGroup.BattleDropRewardId);

            rewards.Add(new Reward
            {
                Name = CalculatorPossession.GetItemName(darkBattleDropReward.PossessionType, darkBattleDropReward.PossessionId),
                Count = darkBattleDropReward.Count
            });
        }

        return rewards;
    }
}

public class FetchEventQuestsCommandArg
{
    public int EventQuestChapterId { get; init; }

    public DifficultyType DifficultyType { get; init; }

    public bool IncludePickupRewards { get; init; }
}
