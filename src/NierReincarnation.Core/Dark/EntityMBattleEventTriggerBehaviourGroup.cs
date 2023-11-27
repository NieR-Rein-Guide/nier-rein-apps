using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleEventTriggerBehaviourGroup))]
public class EntityMBattleEventTriggerBehaviourGroup
{
    [Key(0)]
    public int BattleEventTriggerBehaviourGroupId { get; set; }

    [Key(1)]
    public int BattleEventTriggerBehaviourType { get; set; }

    [Key(2)]
    public int BattleEventTriggerBehaviourId { get; set; }
}
