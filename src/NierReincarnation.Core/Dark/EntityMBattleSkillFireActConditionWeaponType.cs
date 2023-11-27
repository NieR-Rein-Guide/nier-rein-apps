using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleSkillFireActConditionWeaponType))]
public class EntityMBattleSkillFireActConditionWeaponType
{
    [Key(0)]
    public int BattleSkillFireActConditionId { get; set; }

    [Key(1)]
    public WeaponType WeaponType { get; set; }
}
