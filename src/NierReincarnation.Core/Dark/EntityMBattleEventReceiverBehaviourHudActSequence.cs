using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_event_receiver_behaviour_hud_act_sequence")]
public class EntityMBattleEventReceiverBehaviourHudActSequence
{
    [Key(0)]
    public int BattleEventReceiverBehaviourId { get; set; }

    [Key(1)]
    public int HudActSequenceId { get; set; }
}
