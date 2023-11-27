using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediate))]
public class EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediate
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public SkillCooltimeAdvanceType SkillCooltimeAdvanceType { get; set; }

    [Key(2)]
    public ActiveSkillType ActiveSkillType { get; set; }

    [Key(3)]
    public int AdvanceValue { get; set; }
}
