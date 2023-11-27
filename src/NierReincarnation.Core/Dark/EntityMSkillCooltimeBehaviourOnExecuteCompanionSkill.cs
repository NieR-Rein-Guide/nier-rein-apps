using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCooltimeBehaviourOnExecuteCompanionSkill))]
public class EntityMSkillCooltimeBehaviourOnExecuteCompanionSkill
{
    [Key(0)]
    public int SkillCooltimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCooltimeAdvanceValue { get; set; }
}
