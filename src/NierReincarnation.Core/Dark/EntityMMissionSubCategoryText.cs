using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMissionSubCategoryText))]
public class EntityMMissionSubCategoryText
{
    [Key(0)]
    public int MissionSubCategoryId { get; set; }

    [Key(1)]
    public int TextId { get; set; }
}
