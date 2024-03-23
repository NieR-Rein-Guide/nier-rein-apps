using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserDeckLimitContentDeletedCharacter))]
public class EntityIUserDeckLimitContentDeletedCharacter
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int UserDeckNumber { get; set; }

    [Key(2)]
    public int UserDeckCharacterNumber { get; set; }

    [Key(3)]
    public int CostumeId { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
