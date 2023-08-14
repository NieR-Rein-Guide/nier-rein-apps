using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchFateBoardCommand : AbstractDbQueryCommand<FetchFateBoardCommandArg, FateBoard>
{
    public override async Task<FateBoard> ExecuteAsync(FetchFateBoardCommandArg arg)
    {
        if (!arg.IsValid()) return null;

        var darkEventChapter = arg.Entity ?? MasterDb.EntityMEventQuestChapterTable.All.FirstOrDefault(x => x.EventQuestChapterId == arg.EntityId);
        if (darkEventChapter == null) return null;

        FateBoard fateBoard = new()
        {
            Name = string.Format(UserInterfaceTextKey.Quest.kEventChapterTitle, darkEventChapter.NameEventQuestTextId).Localize(),
            StartDateTimeOffset = CalculatorDateTime.FromUnixTime(darkEventChapter.StartDatetime),
            EndDateTimeOffset = CalculatorDateTime.FromUnixTime(darkEventChapter.EndDatetime),
            Seasons = new()
        };

        foreach (var darkLabyrinthSeason in MasterDb.EntityMEventQuestLabyrinthSeasonTable.FindByEventQuestChapterId(darkEventChapter.EventQuestChapterId).OrderBy(x => x.SeasonNumber))
        {
            if (arg.FromDate > CalculatorDateTime.FromUnixTime(darkLabyrinthSeason.StartDatetime)) continue;
            if (arg.ToDate < CalculatorDateTime.FromUnixTime(darkLabyrinthSeason.StartDatetime)) continue;

            var darkDifficultyTypes = MasterDb.EntityMEventQuestSequenceGroupTable.All
                .Where(x => x.EventQuestSequenceGroupId == darkEventChapter.EventQuestSequenceGroupId)
                .Select(x => x.DifficultyType)
                .ToList();

            FateBoardSeason fateBoardSeason = new()
            {
                SeasonNumber = darkLabyrinthSeason.SeasonNumber,
                StartDateTimeOffset = CalculatorDateTime.FromUnixTime(darkLabyrinthSeason.StartDatetime),
                EndDateTimeOffset = CalculatorDateTime.FromUnixTime(darkLabyrinthSeason.EndDatetime),
                Stages = new()
            };
            fateBoard.Seasons.Add(fateBoardSeason);

            foreach (var darkDifficulty in darkDifficultyTypes)
            {
                var quests = await new FetchEventQuestsCommand().ExecuteAsync(new FetchEventQuestsCommandArg
                {
                    EventQuestChapterId = darkEventChapter.EventQuestChapterId,
                    DifficultyType = darkDifficulty
                });

                var darkLabyrinthStages = arg.OnlyLastStage
                    ? new List<EntityMEventQuestLabyrinthStage> { MasterDb.EntityMEventQuestLabyrinthStageTable.FindByEventQuestChapterId(darkLabyrinthSeason.EventQuestChapterId).OrderBy(x => x.StageOrder).Last() }
                    : MasterDb.EntityMEventQuestLabyrinthStageTable.FindByEventQuestChapterId(darkLabyrinthSeason.EventQuestChapterId).OrderBy(x => x.StageOrder).ToList();

                foreach (var darkLabyrinthStage in darkLabyrinthStages)
                {
                    FateBoardStage fateBoardStage = new()
                    {
                        StageNumber = darkLabyrinthStage.StageOrder,
                        Difficulties = new()
                    };
                    fateBoardSeason.Stages.Add(fateBoardStage);

                    var stageQuests = quests
                        .Skip(darkLabyrinthStage.StartSequenceSortOrder - 1)
                        .Take(darkLabyrinthStage.EndSequenceSortOrder - darkLabyrinthStage.StartSequenceSortOrder + 1)
                        .Select(x => new FateBoardQuest(x))
                        .ToList();

                    FateBoardDifficulty fateBoardDifficulty = new()
                    {
                        DifficultyType = darkDifficulty,
                        Quests = stageQuests,
                        Treasures = new(),
                        MissionRewards = new()
                    };
                    fateBoardStage.Difficulties.Add(fateBoardDifficulty);

                    // Mission rewards
                    foreach (var darkLabyrinthAccumulationReward in MasterDb.EntityMEventQuestLabyrinthStageAccumulationRewardGroupTable.FindByEventQuestLabyrinthStageAccumulationRewardGroupId(darkLabyrinthStage.StageAccumulationRewardGroupId))
                    {
                        foreach (var reward in MasterDb.EntityMEventQuestLabyrinthRewardGroupTable.FindByEventQuestLabyrinthRewardGroupId(darkLabyrinthAccumulationReward.EventQuestLabyrinthRewardGroupId))
                        {
                            fateBoardDifficulty.MissionRewards.Add(new MissionReward
                            {
                                MissionName = darkLabyrinthAccumulationReward.QuestMissionClearCount.ToString(),
                                Name = CalculatorPossession.GetItemName(reward.PossessionType, reward.PossessionId),
                                Count = reward.Count
                            });
                        }
                    }

                    // Treasures
                    foreach (var darkLabyrinthReward in MasterDb.EntityMEventQuestLabyrinthRewardGroupTable.FindByEventQuestLabyrinthRewardGroupId(darkLabyrinthStage.StageClearRewardGroupId))
                    {
                        fateBoardDifficulty.Treasures.Add(new Reward
                        {
                            Name = CalculatorPossession.GetItemName(darkLabyrinthReward.PossessionType, darkLabyrinthReward.PossessionId),
                            Count = darkLabyrinthReward.Count
                        });
                    }

                    // Season rewards
                    foreach (var quest in fateBoardDifficulty.Quests)
                    {
                        var darkLabyrinthSeasonRewardGroup = MasterDb.EntityMEventQuestLabyrinthSeasonRewardGroupTable.FindByEventQuestLabyrinthSeasonRewardGroupIdAndHeadQuestId((darkLabyrinthSeason.SeasonRewardGroupId, quest.QuestId));
                        if (darkLabyrinthSeasonRewardGroup == null) continue;

                        foreach (var darkLabyrinthSeasonReward in MasterDb.EntityMEventQuestLabyrinthRewardGroupTable.FindByEventQuestLabyrinthRewardGroupId(darkLabyrinthSeasonRewardGroup.EventQuestLabyrinthRewardGroupId))
                        {
                            quest.SeasonRewards.Add(new Reward
                            {
                                Name = CalculatorPossession.GetItemName(darkLabyrinthSeasonReward.PossessionType, darkLabyrinthSeasonReward.PossessionId),
                                Count = darkLabyrinthSeasonReward.Count
                            });
                        }
                    }
                }
            }
        }

        return fateBoard;
    }
}

public class FetchFateBoardCommandArg : AbstractEntityCommandWithDatesArg<EntityMEventQuestChapter>
{
    public bool OnlyLastStage { get; init; }

    public override bool IsValid()
    {
        return base.IsValid() && (Entity == null || Entity.EventQuestType == EventQuestType.LABYRINTH);
    }
}
