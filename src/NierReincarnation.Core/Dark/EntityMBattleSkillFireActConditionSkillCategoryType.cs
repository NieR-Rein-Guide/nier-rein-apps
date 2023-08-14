using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_skill_fire_act_condition_skill_category_type")]
public class EntityMBattleSkillFireActConditionSkillCategoryType
{
    [Key(0)]
    public int BattleSkillFireActConditionId { get; set; }

    [Key(1)]
    public SkillCategoryType SkillCategoryType { get; set; }
}
