using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_character_board_condition_group")]
public class EntityMCharacterBoardConditionGroup
{
    [Key(0)]
    public int CharacterBoardConditionGroupId { get; set; }

    [Key(1)]
    public ConditionOperationType ConditionOperationType { get; set; }
}
