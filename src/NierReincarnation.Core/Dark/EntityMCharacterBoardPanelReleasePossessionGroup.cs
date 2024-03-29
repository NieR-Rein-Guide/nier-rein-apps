using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoardPanelReleasePossessionGroup))]
public class EntityMCharacterBoardPanelReleasePossessionGroup
{
    [Key(0)]
    public int CharacterBoardPanelReleasePossessionGroupId { get; set; }

    [Key(1)]
    public PossessionType PossessionType { get; set; }

    [Key(2)]
    public int PossessionId { get; set; }

    [Key(3)]
    public int Count { get; set; }

    [Key(4)]
    public int SortOrder { get; set; }
}
