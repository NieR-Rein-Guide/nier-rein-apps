namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class AbnormalResistanceValue
{
    [Key(0)]
    public AbnormalResistancePolarityType AbnormalResistancePolarityType { get; set; }

    [Key(1)]
    public int AbnormalResistanceSkillAbnormalTypeId { get; set; }

    [Key(2)]
    public int BlockProbabilityPermil { get; set; }
}
