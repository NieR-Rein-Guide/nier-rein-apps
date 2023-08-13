namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class BattleSkillType
{
    [Key(0)]
    public SkillCategoryType SkillCategoryType { get; set; }

    [Key(1)]
    public int SkillOrder { get; set; }
}
