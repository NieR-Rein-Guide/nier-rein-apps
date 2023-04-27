using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_pass_reward_group")]
    public class EntityMMissionPassRewardGroup
    {
        [Key(0)]
        public int MissionPassRewardGroupId { get; set; } // 0x10

        [Key(1)]
        public int Level { get; set; } // 0x14

        [Key(2)]
        public bool IsPremium { get; set; } // 0x18

        [Key(3)]
        public int SortOrder { get; set; } // 0x1C

        [Key(4)]
        public PossessionType PossessionType { get; set; } // 0x20

        [Key(5)]
        public int PossessionId { get; set; } // 0x24

        [Key(6)]
        public int Count { get; set; } // 0x28
    }
}
