using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_field_effect_group")]
    public class EntityMFieldEffectGroup
    {
        [Key(0)]
        public int FieldEffectGroupId { get; set; } // 0x10

        [Key(1)]
        public int FieldEffectGroupIndex { get; set; } // 0x14

        [Key(2)]
        public int AbilityId { get; set; } // 0x18

        [Key(3)]
        public int DefaultAbilityLevel { get; set; } // 0x1C

        [Key(4)]
        public FieldEffectApplyScopeType FieldEffectApplyScopeType { get; set; } // 0x20

        [Key(5)]
        public int FieldEffectAssetId { get; set; } // 0x24
    }
}
