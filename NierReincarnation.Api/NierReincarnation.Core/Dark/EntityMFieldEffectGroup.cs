using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_field_effect_group")]
public class EntityMFieldEffectGroup
{
    [Key(0)]
    public int FieldEffectGroupId { get; set; }

    [Key(1)]
    public int FieldEffectGroupIndex { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }

    [Key(3)]
    public int DefaultAbilityLevel { get; set; }

    [Key(4)]
    public FieldEffectApplyScopeType FieldEffectApplyScopeType { get; set; }

    [Key(5)]
    public int FieldEffectAssetId { get; set; }
}
