using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_skill_fire_act_condition_weapon_type")]
public class EntityMBattleSkillFireActConditionWeaponType
{
    [Key(0)]
    public int BattleSkillFireActConditionId { get; set; }

    [Key(1)]
    public WeaponType WeaponType { get; set; }
}
