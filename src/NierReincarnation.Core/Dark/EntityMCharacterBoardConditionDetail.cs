using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoardConditionDetail))]
public class EntityMCharacterBoardConditionDetail
{
    [Key(0)]
    public int CharacterBoardConditionDetailId { get; set; }

    [Key(1)]
    public int DetailIndex { get; set; }

    [Key(2)]
    public int ConditionValue { get; set; }
}
