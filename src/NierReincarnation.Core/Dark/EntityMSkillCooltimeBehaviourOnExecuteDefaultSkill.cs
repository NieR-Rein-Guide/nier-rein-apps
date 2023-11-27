using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCooltimeBehaviourOnExecuteDefaultSkill))]
public class EntityMSkillCooltimeBehaviourOnExecuteDefaultSkill
{
    [Key(0)]
    public int SkillCooltimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCooltimeAdvanceValueOnDefaultSkillGroupId { get; set; }
}
