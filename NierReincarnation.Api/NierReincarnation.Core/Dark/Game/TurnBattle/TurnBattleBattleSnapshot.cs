using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class TurnBattleBattleSnapshot
{
    [Key(0)] // RVA: 0x1DEBD54 Offset: 0x1DEBD54 VA: 0x1DEBD54
    public ProgressDataKey ProgressDataKey { get; set; }
    [Key(1)] // RVA: 0x1DEBD68 Offset: 0x1DEBD68 VA: 0x1DEBD68
    public int SceneId { get; set; }
    [Key(2)] // RVA: 0x1DEBD7C Offset: 0x1DEBD7C VA: 0x1DEBD7C
    public bool IsAuto { get; set; }
    [Key(3)] // RVA: 0x1DEBD90 Offset: 0x1DEBD90 VA: 0x1DEBD90
    public int GameSpeedType { get; set; }
    [Key(4)] // RVA: 0x1DEBDA4 Offset: 0x1DEBDA4 VA: 0x1DEBDA4
    public int WaveNumber { get; set; }
    [Key(5)] // RVA: 0x1DEBDB8 Offset: 0x1DEBDB8 VA: 0x1DEBDB8
    public List<DataBattleDropAssignment> DataBattleDropAssignmentList { get; set; } = new List<DataBattleDropAssignment>();
    [Key(6)] // RVA: 0x1DEBDCC Offset: 0x1DEBDCC VA: 0x1DEBDCC
    public int WaveCapacity { get; set; }
    [Key(7)] // RVA: 0x1DEBDE0 Offset: 0x1DEBDE0 VA: 0x1DEBDE0
    public int EndType { get; set; }
    [Key(8)] // RVA: 0x1DEBDF4 Offset: 0x1DEBDF4 VA: 0x1DEBDF4
    public PartyHash CurrentPlayerDeckPartyHash { get; set; }
    [Key(9)] // RVA: 0x1DEBE08 Offset: 0x1DEBE08 VA: 0x1DEBE08
    public long CumulativeDamageValue { get; set; }
    [Key(10)] // RVA: 0x1DEBE1C Offset: 0x1DEBE1C VA: 0x1DEBE1C
    public int CurrentPhaseOrder { get; set; }
    [Key(11)] // RVA: 0x1DEBE30 Offset: 0x1DEBE30 VA: 0x1DEBE30
    public int LatestActivatedThresholdOrder { get; set; }
    [Key(12)] // RVA: 0x1DEBE44 Offset: 0x1DEBE44 VA: 0x1DEBE44
    public int LatestActivatedThresholdConsecutiveNumber { get; set; }
    [Key(13)] // RVA: 0x1DEBE58 Offset: 0x1DEBE58 VA: 0x1DEBE58
    public long CurrentGaugeValue { get; set; }
    [Key(14)] // RVA: 0x1DEBE6C Offset: 0x1DEBE6C VA: 0x1DEBE6C
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
