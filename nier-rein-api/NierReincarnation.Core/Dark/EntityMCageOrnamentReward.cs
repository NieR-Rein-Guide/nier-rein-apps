using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_cage_ornament_reward")]
    public class EntityMCageOrnamentReward
    {
        [Key(0)]
        public int CageOrnamentRewardId { get; set; } // 0x10
        [Key(1)]
        public int PossessionType { get; set; } // 0x14
        [Key(2)]
        public int PossessionId { get; set; } // 0x18
        [Key(3)]
        public int Count { get; set; } // 0x1C
    }
}