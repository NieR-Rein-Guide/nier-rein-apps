using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionBuff))]
public class EntityMSkillBehaviourActionBuff
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillBuffId { get; set; }
}
