using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionActiveSkillDamageCorrection))]
public class EntityMSkillBehaviourActionActiveSkillDamageCorrection
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int CorrectionValuePermil { get; set; }
}
