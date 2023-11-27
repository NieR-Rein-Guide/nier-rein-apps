using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleEventTriggerBehaviourWaveStart))]
public class EntityMBattleEventTriggerBehaviourWaveStart
{
    [Key(0)]
    public int BattleEventTriggerBehaviourId { get; set; }

    [Key(1)]
    public int WaveNumber { get; set; }
}
