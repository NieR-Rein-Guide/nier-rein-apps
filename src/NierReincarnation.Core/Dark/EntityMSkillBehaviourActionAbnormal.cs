using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionAbnormal))]
public class EntityMSkillBehaviourActionAbnormal
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillBehaviourAbnormalId { get; set; }
}
