using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserPvpDefenseDeck))]
public class EntityIUserPvpDefenseDeck
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int UserDeckNumber { get; set; }

    [Key(2)]
    public long LatestVersion { get; set; }
}
