using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleEventTriggerBehaviourBattleStart))]
public class EntityMBattleEventTriggerBehaviourBattleStart
{
    [Key(0)]
    public int BattleEventTriggerBehaviourId { get; set; }

    [Key(1)]
    public bool TriggerOnBattleRestore { get; set; }
}
