using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_sequence_reward_group")]
    public class EntityMGimmickSequenceRewardGroup
    {
        [Key(0)]
        public int GimmickSequenceRewardGroupId { get; set; } // 0x10

        [Key(1)]
        public int GroupIndex { get; set; } // 0x14

        [Key(2)]
        public PossessionType PossessionType { get; set; } // 0x18

        [Key(3)]
        public int PossessionId { get; set; } // 0x1C

        [Key(4)]
        public int Count { get; set; } // 0x20
    }
}
