using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_event_receiver_behaviour_radio_message")]
public class EntityMBattleEventReceiverBehaviourRadioMessage
{
    [Key(0)]
    public int BattleEventReceiverBehaviourId { get; set; }

    [Key(1)]
    public int SpeakerId { get; set; }

    [Key(2)]
    public string ScenarioKey { get; set; }
}
