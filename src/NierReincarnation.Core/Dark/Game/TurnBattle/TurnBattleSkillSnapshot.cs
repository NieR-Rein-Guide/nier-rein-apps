namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class TurnBattleSkillSnapshot
{
    [Key(0)]
    public ProgressDataKey ProgressDataKey { get; set; }

    [Key(1)]
    public SkillHash SkillHash { get; set; }

    [Key(2)]
    public int DynamicCurrentCoolTime { get; set; }

    [Key(3)]
    public int DynamicMaxCoolTime { get; set; }

    [Key(4)]
    public int UsedCount { get; set; }

    [Key(5)]
    public List<int> CoolTimeModifyValueList { get; set; } = new List<int>();
}
