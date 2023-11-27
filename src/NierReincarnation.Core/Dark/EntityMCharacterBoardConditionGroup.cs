using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterBoardConditionGroup))]
public class EntityMCharacterBoardConditionGroup
{
    [Key(0)]
    public int CharacterBoardConditionGroupId { get; set; }

    [Key(1)]
    public ConditionOperationType ConditionOperationType { get; set; }
}
