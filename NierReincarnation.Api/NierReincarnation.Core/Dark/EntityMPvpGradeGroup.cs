using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_grade_group")]
    public class EntityMPvpGradeGroup
    {
        [Key(0)]
        public int PvpGradeGroupId { get; set; } // 0x10

        [Key(1)]
        public int PvpGradeId { get; set; } // 0x14

        [Key(2)]
        public int NecessaryPvpPoint { get; set; } // 0x18

        [Key(3)]
        public int IconAssetId { get; set; } // 0x1C

        [Key(4)]
        public int PvpGradeWeeklyRewardGroupId { get; set; } // 0x20

        [Key(5)]
        public int PvpGradeOneMatchRewardGroupId { get; set; } // 0x24
    }
}
