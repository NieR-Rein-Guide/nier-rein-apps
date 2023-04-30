using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_condition")]
    public class EntityMCharacterBoardCondition
    {
        [Key(0)]
        public int CharacterBoardConditionGroupId { get; set; } // 0x10

        [Key(1)]
        public int GroupIndex { get; set; } // 0x14

        [Key(2)]
        public CharacterBoardConditionType CharacterBoardConditionType { get; set; } // 0x18

        [Key(3)]
        public int CharacterBoardConditionDetailId { get; set; } // 0x1C

        [Key(4)]
        public int CharacterBoardConditionIgnoreId { get; set; } // 0x20

        [Key(5)]
        public int ConditionValue { get; set; } // 0x24
    }
}
