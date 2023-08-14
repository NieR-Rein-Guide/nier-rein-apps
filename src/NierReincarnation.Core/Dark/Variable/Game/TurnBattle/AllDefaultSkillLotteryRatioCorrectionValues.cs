namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class AllDefaultSkillLotteryRatioCorrectionValues
{
    [Key(0)]
    public List<DefaultSkillLotteryRatioCorrectionValues> List { get; set; } = new List<DefaultSkillLotteryRatioCorrectionValues>();
}
