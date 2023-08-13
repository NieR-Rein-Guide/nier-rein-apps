using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_field_effect_bless_relation")]
public class EntityMFieldEffectBlessRelation
{
    [Key(0)]
    public int FieldEffectGroupId { get; set; }

    [Key(1)]
    public int FieldEffectBlessRelationIndex { get; set; }

    [Key(2)]
    public int WeaponId { get; set; }
}
