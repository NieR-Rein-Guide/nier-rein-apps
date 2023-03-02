using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_explore")]
    public class EntityMExplore
    {
        [Key(0)]
        public int ExploreId { get; set; } // 0x10
        [Key(1)]
        public int ExploreUnlockConditionId { get; set; } // 0x14
        [Key(2)]
        public long StartDatetime { get; set; } // 0x18
        [Key(3)]
        public int ConsumeItemCount { get; set; } // 0x20
        [Key(4)]
        public int RewardLotteryCount { get; set; } // 0x24
    }
}