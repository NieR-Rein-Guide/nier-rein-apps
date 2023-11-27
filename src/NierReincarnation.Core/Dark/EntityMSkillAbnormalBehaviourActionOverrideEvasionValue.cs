using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalBehaviourActionOverrideEvasionValue))]
public class EntityMSkillAbnormalBehaviourActionOverrideEvasionValue
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public int CorrectionValuePermil { get; set; }
}
