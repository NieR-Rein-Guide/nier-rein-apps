using MessagePack;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class ActorBuffParameter
{
    [Key(0)] // RVA: 0x1DEB710 Offset: 0x1DEB710 VA: 0x1DEB710
    public BuffTypeId BuffTypeId { get; set; }
    [Key(1)] // RVA: 0x1DEB724 Offset: 0x1DEB724 VA: 0x1DEB724
    public int Lifetime { get; set; }
    [Key(2)] // RVA: 0x1DEB738 Offset: 0x1DEB738 VA: 0x1DEB738
    public int CurrentPower { get; set; }
	}
