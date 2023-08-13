using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_consumable_item")]
public class EntityIUserConsumableItem
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int ConsumableItemId { get; set; }

    [Key(2)]
    public int Count { get; set; }

    [Key(3)]
    public long FirstAcquisitionDatetime { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
