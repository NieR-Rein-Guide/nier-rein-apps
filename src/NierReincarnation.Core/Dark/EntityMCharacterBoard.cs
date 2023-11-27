using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoard))]
public class EntityMCharacterBoard
{
    [Key(0)]
    public int CharacterBoardId { get; set; }

    [Key(1)]
    public int CharacterBoardGroupId { get; set; }

    [Key(2)]
    public int CharacterBoardUnlockConditionGroupId { get; set; }

    [Key(3)]
    public int ReleaseRank { get; set; }
}
