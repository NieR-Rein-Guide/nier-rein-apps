using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleSkillFireActConditionSkillCategoryType))]
public class EntityMBattleSkillFireActConditionSkillCategoryType
{
    [Key(0)]
    public int BattleSkillFireActConditionId { get; set; }

    [Key(1)]
    public SkillCategoryType SkillCategoryType { get; set; }
}
