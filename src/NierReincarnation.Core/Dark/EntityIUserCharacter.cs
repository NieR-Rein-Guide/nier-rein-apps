using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserCharacter))]
public class EntityIUserCharacter
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int Level { get; set; }

    [Key(3)]
    public int Exp { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
