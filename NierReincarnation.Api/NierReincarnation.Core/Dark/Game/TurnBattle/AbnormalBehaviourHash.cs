using MessagePack;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class AbnormalBehaviourHash
{
    [Key(0)] // RVA: 0x1DEC2D0 Offset: 0x1DEC2D0 VA: 0x1DEC2D0
    public AbnormalHash AbnormalHash { get; set; }

    [Key(1)] // RVA: 0x1DEC2E4 Offset: 0x1DEC2E4 VA: 0x1DEC2E4
    public int AbnormalBehaviourIndex { get; set; }
}
