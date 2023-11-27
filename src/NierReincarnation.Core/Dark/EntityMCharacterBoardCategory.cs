using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoardCategory))]
public class EntityMCharacterBoardCategory
{
    [Key(0)]
    public int CharacterBoardCategoryId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }
}
