using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMovie))]
public class EntityMMovie
{
    [Key(0)]
    public int MovieId { get; set; }

    [Key(1)]
    public int AssetId { get; set; }
}
