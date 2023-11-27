using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalBehaviourActionHitRatioDown))]
public class EntityMSkillAbnormalBehaviourActionHitRatioDown
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public int Value { get; set; }
}
