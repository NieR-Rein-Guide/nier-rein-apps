using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_stage")]
    public class EntityMEventQuestLabyrinthStage
    {
        [Key(0)]
        public int EventQuestChapterId { get; set; }

        [Key(1)]
        public int StageOrder { get; set; }

        [Key(2)]
        public int StartSequenceSortOrder { get; set; }

        [Key(3)]
        public int EndSequenceSortOrder { get; set; }

        [Key(4)]
        public int StageClearRewardGroupId { get; set; }

        [Key(5)]
        public int StageAccumulationRewardGroupId { get; set; }

        [Key(6)]
        public int Mob1Id { get; set; }

        [Key(7)]
        public int Mob2Id { get; set; }

        [Key(8)]
        public int TreasureAssetId { get; set; }
    }
}
