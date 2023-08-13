namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class TurnBattleBattleSnapshot
{
    [Key(0)]
    public ProgressDataKey ProgressDataKey { get; set; }

    [Key(1)]
    public int SceneId { get; set; }

    [Key(2)]
    public bool IsAuto { get; set; }

    [Key(3)]
    public int GameSpeedType { get; set; }

    [Key(4)]
    public int WaveNumber { get; set; }

    [Key(5)]
    public List<DataBattleDropAssignment> DataBattleDropAssignmentList { get; set; } = new List<DataBattleDropAssignment>();

    [Key(6)]
    public int WaveCapacity { get; set; }

    [Key(7)]
    public int EndType { get; set; }

    [Key(8)]
    public PartyHash CurrentPlayerDeckPartyHash { get; set; }

    [Key(9)]
    public long CumulativeDamageValue { get; set; }

    [Key(10)]
    public int CurrentPhaseOrder { get; set; }

    [Key(11)]
    public int LatestActivatedThresholdOrder { get; set; }

    [Key(12)]
    public int LatestActivatedThresholdConsecutiveNumber { get; set; }

    [Key(13)]
    public long CurrentGaugeValue { get; set; }

    [Key(14)]
    public int BattleReportRandomDisplayType { get; set; }

    public static ProgressDataKey GenerateProgressDataKey(int battleSceneId)
    {
        return new ProgressDataKey
        {
            Key0 = 4,
            Key1 = battleSceneId,
            Key2 = 0
        };
    }
}
