using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeSpecialActActiveSkill))]
public class EntityMCostumeSpecialActActiveSkill
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public int SkillActIndex { get; set; }

    [Key(2)]
    public CostumeSpecialActActiveSkillConditionType CostumeSpecialActActiveSkillConditionType { get; set; }

    [Key(3)]
    public int CostumeSpecialActActiveSkillConditionId { get; set; }
}
