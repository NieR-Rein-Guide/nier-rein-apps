using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_login_bonus_stamp")]
public class EntityMLoginBonusStamp
{
    [Key(0)]
    public int LoginBonusId { get; set; }

    [Key(1)]
    public int LowerPageNumber { get; set; }

    [Key(2)]
    public int StampNumber { get; set; }

    [Key(3)]
    public PossessionType RewardPossessionType { get; set; }

    [Key(4)]
    public int RewardPossessionId { get; set; }

    [Key(5)]
    public int RewardCount { get; set; }
}
