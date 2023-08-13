using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_field_effect_decrease_point")]
public class EntityMFieldEffectDecreasePoint
{
    [Key(0)]
    public int WeaponId { get; set; }

    [Key(1)]
    public int FieldEffectAbilityId { get; set; }

    [Key(2)]
    public int DecreasePoint { get; set; }
}
