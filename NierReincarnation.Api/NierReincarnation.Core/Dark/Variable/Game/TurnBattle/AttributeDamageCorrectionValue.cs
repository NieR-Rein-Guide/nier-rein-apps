using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class AttributeDamageCorrectionValue
{
    [Key(0)] // RVA: 0x1DEB798 Offset: 0x1DEB798 VA: 0x1DEB798
    public AttributeType AttributeType { get; set; }

    [Key(1)] // RVA: 0x1DEB7AC Offset: 0x1DEB7AC VA: 0x1DEB7AC
    public int CorrectionValue { get; set; }

    [Key(2)] // RVA: 0x1DEB7C0 Offset: 0x1DEB7C0 VA: 0x1DEB7C0
    public DamageCorrectionOverlapType OverlapType { get; set; }

    [Key(3)] // RVA: 0x1DEB7D4 Offset: 0x1DEB7D4 VA: 0x1DEB7D4
    public bool IsExcepting { get; set; }
}
