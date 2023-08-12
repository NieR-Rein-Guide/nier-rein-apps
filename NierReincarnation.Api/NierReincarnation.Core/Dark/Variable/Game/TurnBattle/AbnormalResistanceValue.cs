using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class AbnormalResistanceValue
{
    [Key(0)] // RVA: 0x1DEB69C Offset: 0x1DEB69C VA: 0x1DEB69C
    public AbnormalResistancePolarityType AbnormalResistancePolarityType { get; set; }

    [Key(1)] // RVA: 0x1DEB6B0 Offset: 0x1DEB6B0 VA: 0x1DEB6B0
    public int AbnormalResistanceSkillAbnormalTypeId { get; set; }

    [Key(2)] // RVA: 0x1DEB6C4 Offset: 0x1DEB6C4 VA: 0x1DEB6C4
    public int BlockProbabilityPermil { get; set; }
}
