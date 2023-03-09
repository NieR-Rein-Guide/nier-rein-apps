using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_grade_weekly_reward_group")]
    public class EntityMPvpGradeWeeklyRewardGroup
    {
        [Key(0)]
        public int PvpGradeWeeklyRewardGroupId { get; set; } // 0x10
        [Key(1)]
        public int PvpRewardId { get; set; } // 0x14
        [Key(2)]
        public int SortOrder { get; set; } // 0x18
    }
}