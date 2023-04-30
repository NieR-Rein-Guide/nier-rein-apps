using Google.Protobuf.Collections;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public static class CalculatorLabyrinth
    {
        public static readonly DifficultyType kLabyrinthQuestDifficultyType = DifficultyType.NORMAL; // 0x0
        public static readonly int kMaxReachRewardCountSingleQuest = 7; // 0x4
        private static readonly int kInvalidSearchIndex = -1; // 0x8
        private static readonly int kReceivableReachRewardResultdays = 30; // 0xC
        public static readonly int kMaxStageQuestBgAssetCount = 3; // 0x10
        private static readonly string kStageQuestBgAssetPath = "ui)quest)labyrinth)bg)labyrinth_mark_quest_{0:D2}_{1}"; // 0x18
        public static readonly int kMobAssetIndex = 0; // 0x20
        public static readonly int kMobAssetEffectIndex = 1; // 0x24
        private static readonly string kMobAssetPath = "ui)quest)labyrinth)mob)labyrinth_mob_{0:D2}"; // 0x28
        private static readonly string kMobEffAssetPath = "ui)quest)labyrinth)mob)labyrinth_mob_{0:D2}_eff"; // 0x30
        public static readonly int kTreasureOpenAssetIndex = 0; // 0x38
        public static readonly int kTreasureCloseAssetIndex = 1; // 0x3C
        public static readonly int kTreasureCloseEffectAssetIndex = 2; // 0x40
        private static readonly string kTreasureOpenAssetPath = "ui)quest)labyrinth)treasure)labyrinth_mark_treasure_{0:D2}_open"; // 0x48
        private static readonly string kTreasureCloseAssetPath = "ui)quest)labyrinth)treasure)labyrinth_mark_treasure_{0:D2}_close"; // 0x50
        private static readonly string kTreasureCloseEffectAssetPath = "ui)quest)labyrinth)treasure)labyrinth_mark_treasure_{0:D2}_close_eff"; // 0x58
        private static readonly string kMobEffectAssetPath = "effect)labyrinth)prefabs)ef_mob_{0}"; // 0x60
        private static readonly string kMobEffectDarkName = "dark"; // 0x68
        private static readonly string kMobEffectFireName = "fire"; // 0x70
        private static readonly string kMobEffectWindName = "wind"; // 0x78
        private static readonly string kMobEffectLightName = "light"; // 0x80
        private static readonly string kMobEffectWaterName = "water"; // 0x88

        private static readonly int kFirstClearCount = 1; // 0xA0
        private static readonly int kDefaultQuestMissionClearCount = 0; // 0xA4
        private static readonly int kMaxStageQuestCount = 5; // 0xA8

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
}
