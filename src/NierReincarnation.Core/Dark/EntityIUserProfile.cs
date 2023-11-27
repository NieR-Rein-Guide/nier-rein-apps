using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserProfile))]
public class EntityIUserProfile
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string Name { get; set; }

    [Key(2)]
    public long NameUpdateDatetime { get; set; }

    [Key(3)]
    public string Message { get; set; }

    [Key(4)]
    public long MessageUpdateDatetime { get; set; }

    [Key(5)]
    public int FavoriteCostumeId { get; set; }

    [Key(6)]
    public long FavoriteCostumeIdUpdateDatetime { get; set; }

    [Key(7)]
    public long LatestVersion { get; set; }
}
