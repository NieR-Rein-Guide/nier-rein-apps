using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_grade_one_match_reward")]
    public class EntityMPvpGradeOneMatchReward
    {
        [Key(0)]
        public int PvpGradeOneMatchRewardId { get; set; }

        [Key(1)]
        public int PvpRewardId { get; set; }

        [Key(2)]
        public int SortOrder { get; set; }
    }
}
