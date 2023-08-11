using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_behaviour_activation_condition_wave_number")]
public class EntityMSkillBehaviourActivationConditionWaveNumber
{
    [Key(0)]
    public int SkillBehaviourActivationConditionId { get; set; }

    [Key(1)]
    public int WaveNumber { get; set; }
}
