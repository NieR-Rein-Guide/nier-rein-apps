using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCooltimeBehaviourOnExecuteActiveSkill))]
public class EntityMSkillCooltimeBehaviourOnExecuteActiveSkill
{
    [Key(0)]
    public int SkillCooltimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCooltimeAdvanceValue { get; set; }
}
