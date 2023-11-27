using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserAutoSaleSettingDetail))]
public class EntityIUserAutoSaleSettingDetail
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int PossessionAutoSaleItemType { get; set; }

    [Key(2)]
    public string PossessionAutoSaleItemValue { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
