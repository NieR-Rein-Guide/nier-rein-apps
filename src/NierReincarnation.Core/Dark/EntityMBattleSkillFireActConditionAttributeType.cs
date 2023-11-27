using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleSkillFireActConditionAttributeType))]
public class EntityMBattleSkillFireActConditionAttributeType
{
    [Key(0)]
    public int BattleSkillFireActConditionId { get; set; }

    [Key(1)]
    public AttributeType AttributeType { get; set; }
}
