using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActivationConditionWaveNumber))]
public class EntityMSkillBehaviourActivationConditionWaveNumber
{
    [Key(0)]
    public int SkillBehaviourActivationConditionId { get; set; }

    [Key(1)]
    public int WaveNumber { get; set; }
}
