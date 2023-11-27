using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoardStatusUp))]
public class EntityMCharacterBoardStatusUp
{
    [Key(0)]
    public int CharacterBoardStatusUpId { get; set; }

    [Key(1)]
    public CharacterBoardStatusUpType CharacterBoardStatusUpType { get; set; }

    [Key(2)]
    public int CharacterBoardEffectTargetGroupId { get; set; }
}
