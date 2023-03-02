using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_stage")]
    public class EntityMEventQuestLabyrinthStage
    {
        [Key(0)]
        public int EventQuestChapterId { get; set; } // 0x10
        [Key(1)]
        public int StageOrder { get; set; } // 0x14
        [Key(2)]
        public int StartSequenceSortOrder { get; set; } // 0x18
        [Key(3)]
        public int EndSequenceSortOrder { get; set; } // 0x1C
        [Key(4)]
        public int StageClearRewardGroupId { get; set; } // 0x20
        [Key(5)]
        public int StageAccumulationRewardGroupId { get; set; } // 0x24
        [Key(6)]
        public int Mob1Id { get; set; } // 0x28
        [Key(7)]
        public int Mob2Id { get; set; } // 0x2C
        [Key(8)]
        public int TreasureAssetId { get; set; } // 0x30
    }
}