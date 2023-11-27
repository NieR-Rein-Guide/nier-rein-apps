using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalBehaviourActionBuffResistance))]
public class EntityMSkillAbnormalBehaviourActionBuffResistance
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public BuffResistanceType BuffResistanceType { get; set; }

    [Key(2)]
    public BuffResistanceStatusKindType BuffResistanceStatusKindType { get; set; }

    [Key(3)]
    public int BlockProbabilityPermil { get; set; }
}
