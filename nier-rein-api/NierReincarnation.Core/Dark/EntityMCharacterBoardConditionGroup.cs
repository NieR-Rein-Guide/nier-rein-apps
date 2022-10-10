using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_condition_group")]
    public class EntityMCharacterBoardConditionGroup
    {
        [Key(0)]
        public int CharacterBoardConditionGroupId { get; set; } // 0x10
        [Key(1)]
        public int ConditionOperationType { get; set; } // 0x14
    }
}