using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class BuffTypeId
{
    [Key(0)] // RVA: 0x1DEB75C Offset: 0x1DEB75C VA: 0x1DEB75C
    public BuffType BuffType { get; set; }

    [Key(1)] // RVA: 0x1DEB770 Offset: 0x1DEB770 VA: 0x1DEB770
    public StatusKindType StatusType { get; set; }
}
