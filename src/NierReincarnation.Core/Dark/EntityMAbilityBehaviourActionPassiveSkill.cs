using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMAbilityBehaviourActionPassiveSkill))]
public class EntityMAbilityBehaviourActionPassiveSkill
{
    [Key(0)]
    public int AbilityBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillDetailId { get; set; }
}
