using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_damage_multiply_target_specified_costume_group")]
public class EntityMSkillDamageMultiplyTargetSpecifiedCostumeGroup
{
    public int TargetSpecifiedCostumeGroupId { get; set; }

    public int TargetSpecifiedCostumeGroupIndex { get; set; }

    public int CostumeId { get; set; }
}
