namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DefaultSkillLotteryRatioCorrectionValues
{
    [Key(0)]
    public List<DefaultSkillLotteryRatioCorrectionValue> List { get; set; } = new List<DefaultSkillLotteryRatioCorrectionValue>();
}
