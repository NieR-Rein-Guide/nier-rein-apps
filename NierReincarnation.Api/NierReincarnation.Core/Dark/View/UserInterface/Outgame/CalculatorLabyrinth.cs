using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public static class CalculatorLabyrinth
{
    public static readonly DifficultyType kLabyrinthQuestDifficultyType = DifficultyType.NORMAL;
    public static readonly int kMaxReachRewardCountSingleQuest = 7;
    private const int kInvalidSearchIndex = -1;
    private const int kReceivableReachRewardResultdays = 30;
    public static readonly int kMaxStageQuestBgAssetCount = 3;
    private const string kStageQuestBgAssetPath = "ui)quest)labyrinth)bg)labyrinth_mark_quest_{0:D2}_{1}";
    public static readonly int kMobAssetIndex;
    public static readonly int kMobAssetEffectIndex = 1;
    private const string kMobAssetPath = "ui)quest)labyrinth)mob)labyrinth_mob_{0:D2}";
    private const string kMobEffAssetPath = "ui)quest)labyrinth)mob)labyrinth_mob_{0:D2}_eff";
    public static readonly int kTreasureOpenAssetIndex;
    public static readonly int kTreasureCloseAssetIndex = 1;
    public static readonly int kTreasureCloseEffectAssetIndex = 2;
    private const string kTreasureOpenAssetPath = "ui)quest)labyrinth)treasure)labyrinth_mark_treasure_{0:D2}_open";
    private const string kTreasureCloseAssetPath = "ui)quest)labyrinth)treasure)labyrinth_mark_treasure_{0:D2}_close";
    private const string kTreasureCloseEffectAssetPath = "ui)quest)labyrinth)treasure)labyrinth_mark_treasure_{0:D2}_close_eff";
    private const string kMobEffectAssetPath = "effect)labyrinth)prefabs)ef_mob_{0}";
    private const string kMobEffectDarkName = "dark";
    private const string kMobEffectFireName = "fire";
    private const string kMobEffectWindName = "wind";
    private const string kMobEffectLightName = "light";
    private const string kMobEffectWaterName = "water";

    private const int kFirstClearCount = 1;
    private static readonly int kDefaultQuestMissionClearCount;
    private const int kMaxStageQuestCount = 5;

    public static DataLabyrinthQuestList CreateDataLabyrinthQuestList(int eventQuestChapterId /*, ArtStringBuilder artStringBuilder*/)
    {
        var chapterTable = DatabaseDefine.Master.EntityMEventQuestChapterTable;
        var eventChapter = chapterTable.FindByEventQuestChapterId(eventQuestChapterId);
        if (eventChapter == null)
            return null;

        var sequenceGroupTable = DatabaseDefine.Master.EntityMEventQuestSequenceGroupTable;
        var sequenceGroup = sequenceGroupTable.FindByEventQuestSequenceGroupIdAndDifficultyType((eventChapter.EventQuestSequenceGroupId, kLabyrinthQuestDifficultyType));
        if (sequenceGroup == null)
            return null;

        var labyrinthStageTable = DatabaseDefine.Master.EntityMEventQuestLabyrinthStageTable;
        var labyrinthStages = labyrinthStageTable.FindByEventQuestChapterId(eventQuestChapterId);
        if (!labyrinthStages.Any())
            return null;

        var questList = new List<DataLabyrinthQuestListStage>();
        var chapterName = string.Format(UserInterfaceTextKey.Quest.kEventChapterTitle, eventChapter.NameEventQuestTextId).Localize();

        if (labyrinthStages.Count < 1)
            return new DataLabyrinthQuestList(chapterName, questList);

        foreach (var labyrinthStage in labyrinthStages)
        {
            var sequenceTable = DatabaseDefine.Master.EntityMEventQuestSequenceTable;
            var sequences = sequenceTable.FindRangeByEventQuestSequenceIdAndSortOrder((sequenceGroup.EventQuestSequenceId, labyrinthStage.StartSequenceSortOrder), (sequenceGroup.EventQuestSequenceId, labyrinthStage.EndSequenceSortOrder));

            var firstSequence = sequences.First();
            if (firstSequence.EventQuestSequenceId != sequenceGroup.EventQuestSequenceId)
                continue;

            var stageQuests = new List<DataLabyrinthQuestListQuest>(sequences.Count);
            if (sequences.Count > 0)
                foreach (var sequence in sequences)
                    stageQuests.Add(new DataLabyrinthQuestListQuest(sequence.QuestId, sequence.SortOrder));

            stageQuests.Sort(DataLabyrinthQuestListQuestComparer.InstanceAscending);

            var stageName = UserInterfaceTextKey.Quest.Labyrinth.KQuestListStageName.LocalizeWithParams(labyrinthStage.StageOrder);
            questList.Add(new DataLabyrinthQuestListStage(labyrinthStage.StageOrder, stageName, stageQuests));
        }

        questList.Sort(DataLabyrinthQuestListStageComparer.InstanceAscending);

        return new DataLabyrinthQuestList(chapterName, questList);
    }
}
