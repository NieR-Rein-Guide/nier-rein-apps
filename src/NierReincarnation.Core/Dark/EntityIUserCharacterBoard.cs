using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserCharacterBoard))]
public class EntityIUserCharacterBoard
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CharacterBoardId { get; set; }

    [Key(2)]
    public int PanelReleaseBit1 { get; set; }

    [Key(3)]
    public int PanelReleaseBit2 { get; set; }

    [Key(4)]
    public int PanelReleaseBit3 { get; set; }

    [Key(5)]
    public int PanelReleaseBit4 { get; set; }

    [Key(6)]
    public long LatestVersion { get; set; }
}
