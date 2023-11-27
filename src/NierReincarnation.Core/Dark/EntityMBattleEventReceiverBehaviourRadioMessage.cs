using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleEventReceiverBehaviourRadioMessage))]
public class EntityMBattleEventReceiverBehaviourRadioMessage
{
    [Key(0)]
    public int BattleEventReceiverBehaviourId { get; set; }

    [Key(1)]
    public int SpeakerId { get; set; }

    [Key(2)]
    public string ScenarioKey { get; set; }
}
