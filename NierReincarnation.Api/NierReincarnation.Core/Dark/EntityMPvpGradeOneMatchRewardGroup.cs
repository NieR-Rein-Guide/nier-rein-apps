using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_grade_one_match_reward_group")]
    public class EntityMPvpGradeOneMatchRewardGroup
    {
        [Key(0)]
        public int PvpGradeOneMatchRewardGroupId { get; set; }

        [Key(1)]
        public int PvpGradeOneMatchRewardId { get; set; }

        [Key(2)]
        public int Weight { get; set; }
    }
}
