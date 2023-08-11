using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_grade_group")]
    public class EntityMPvpGradeGroup
    {
        [Key(0)]
        public int PvpGradeGroupId { get; set; }

        [Key(1)]
        public int PvpGradeId { get; set; }

        [Key(2)]
        public int NecessaryPvpPoint { get; set; }

        [Key(3)]
        public int IconAssetId { get; set; }

        [Key(4)]
        public int PvpGradeWeeklyRewardGroupId { get; set; }

        [Key(5)]
        public int PvpGradeOneMatchRewardGroupId { get; set; }
    }
}
