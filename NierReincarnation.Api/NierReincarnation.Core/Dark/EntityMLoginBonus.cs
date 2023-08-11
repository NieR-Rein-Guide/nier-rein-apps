using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_login_bonus")]
public class EntityMLoginBonus
{
    [Key(0)]
    public int LoginBonusId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int LoginBonusStartConditionId { get; set; }

    [Key(3)]
    public int TotalPageCount { get; set; }

    [Key(4)]
    public long StartDatetime { get; set; }

    [Key(5)]
    public long EndDatetime { get; set; }

    [Key(6)]
    public long StampReceiveEndDatetime { get; set; }

    [Key(7)]
    public string LoginBonusAssetName { get; set; }
}
