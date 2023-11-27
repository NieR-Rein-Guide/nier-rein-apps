using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserDeckTypeNote))]
public class EntityIUserDeckTypeNote
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public DeckType DeckType { get; set; }

    [Key(2)]
    public int MaxDeckPower { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
