using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_costume")]
public class EntityIUserCostume
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserCostumeUuid { get; set; }

    [Key(2)]
    public int CostumeId { get; set; }

    [Key(3)]
    public int LimitBreakCount { get; set; }

    [Key(4)]
    public int Level { get; set; }

    [Key(5)]
    public int Exp { get; set; }

    [Key(6)]
    public int HeadupDisplayViewId { get; set; }

    [Key(7)]
    public long AcquisitionDatetime { get; set; }

    [Key(8)]
    public int AwakenCount { get; set; }

    [Key(9)]
    public long LatestVersion { get; set; }
}
