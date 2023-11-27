using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeSpecialActActiveSkillConditionAttribute))]
public class EntityMCostumeSpecialActActiveSkillConditionAttribute
{
    [Key(0)]
    public int CostumeSpecialActActiveSkillConditionId { get; set; }

    [Key(1)]
    public AttributeType CostumeSpecialActActiveSkillConditionAttributeType { get; set; }
}
