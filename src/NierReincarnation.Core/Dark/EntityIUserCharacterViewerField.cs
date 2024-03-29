using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserCharacterViewerField))]
public class EntityIUserCharacterViewerField
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CharacterViewerFieldId { get; set; }

    [Key(2)]
    public long ReleaseDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
