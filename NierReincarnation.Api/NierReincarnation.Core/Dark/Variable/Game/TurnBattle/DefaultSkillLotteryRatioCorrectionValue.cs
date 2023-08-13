namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DefaultSkillLotteryRatioCorrectionValue
{
    [Key(0)]
    public int Value { get; set; }

    [Key(1)]
    public bool IsMul { get; set; }
}
