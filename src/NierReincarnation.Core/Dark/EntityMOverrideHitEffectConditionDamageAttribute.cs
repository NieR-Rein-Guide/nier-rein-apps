using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMOverrideHitEffectConditionDamageAttribute))]
public class EntityMOverrideHitEffectConditionDamageAttribute
{
    [Key(0)]
    public int OverrideHitEffectConditionId { get; set; }

    [Key(1)]
    public bool IsExcepting { get; set; }

    [Key(2)]
    public AttributeType AttributeType { get; set; }
}
