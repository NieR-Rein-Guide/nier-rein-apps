using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_reward_group")]
    public class EntityMBigHuntRewardGroup
    {
        [Key(0)]
        public int BigHuntRewardGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int PossessionType { get; set; } // 0x18
        [Key(3)]
        public int PossessionId { get; set; } // 0x1C
        [Key(4)]
        public int Count { get; set; } // 0x20
    }
}