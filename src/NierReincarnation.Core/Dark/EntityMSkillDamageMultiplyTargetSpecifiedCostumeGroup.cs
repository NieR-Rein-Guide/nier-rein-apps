using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillDamageMultiplyTargetSpecifiedCostumeGroup))]
public class EntityMSkillDamageMultiplyTargetSpecifiedCostumeGroup
{
    public int TargetSpecifiedCostumeGroupId { get; set; }

    public int TargetSpecifiedCostumeGroupIndex { get; set; }

    public int CostumeId { get; set; }
}
