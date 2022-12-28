using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip_display_condition_group")]
    public class EntityMTipDisplayConditionGroup
    {
        [Key(0)]
        public int TipDisplayConditionGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public TipDisplayConditionType TipDisplayConditionType { get; set; } // 0x18
        [Key(3)]
        public int ConditionValue { get; set; } // 0x1C
        [Key(4)]
        public ConditionOperationType ConditionOperationType { get; set; } // 0x20
    }
}