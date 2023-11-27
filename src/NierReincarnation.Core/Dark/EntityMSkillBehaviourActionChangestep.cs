using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionChangestep))]
public class EntityMSkillBehaviourActionChangestep
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int Step { get; set; }
}
