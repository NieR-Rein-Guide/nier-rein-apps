using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeProperAttributeHpBonus))]
public class EntityMCostumeProperAttributeHpBonus
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public AttributeType CostumeProperAttributeType { get; set; }

    [Key(2)]
    public int MainWeaponHpAdditionalValue { get; set; }

    [Key(3)]
    public int SubWeaponHpAdditionalValue { get; set; }
}
