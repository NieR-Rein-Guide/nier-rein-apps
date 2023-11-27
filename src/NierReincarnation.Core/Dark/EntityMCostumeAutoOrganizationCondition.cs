using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeAutoOrganizationCondition))]
public class EntityMCostumeAutoOrganizationCondition
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public CostumeAutoOrganizationConditionType CostumeAutoOrganizationConditionType { get; set; }

    [Key(2)]
    public int TargetValue { get; set; }
}
