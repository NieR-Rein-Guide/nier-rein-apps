using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_event_trigger_behaviour_wave_start")]
public class EntityMBattleEventTriggerBehaviourWaveStart
{
    [Key(0)]
    public int BattleEventTriggerBehaviourId { get; set; }

    [Key(1)]
    public int WaveNumber { get; set; }
}
