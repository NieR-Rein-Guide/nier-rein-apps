using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_costume_lottery_effect_status_up")]
public class EntityIUserCostumeLotteryEffectStatusUp
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserCostumeUuid { get; set; }

    [Key(2)]
    public StatusCalculationType StatusCalculationType { get; set; }

    [Key(3)]
    public int Hp { get; set; }

    [Key(4)]
    public int Attack { get; set; }

    [Key(5)]
    public int Vitality { get; set; }

    [Key(6)]
    public int Agility { get; set; }

    [Key(7)]
    public int CriticalRatio { get; set; }

    [Key(8)]
    public int CriticalAttack { get; set; }

    [Key(9)]
    public long LatestVersion { get; set; }
}
