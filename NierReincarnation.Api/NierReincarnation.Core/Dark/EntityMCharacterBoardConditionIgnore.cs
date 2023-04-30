using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_condition_ignore")]
    public class EntityMCharacterBoardConditionIgnore
    {
        [Key(0)]
        public int CharacterBoardConditionIgnoreId { get; set; } // 0x10

        [Key(1)]
        public int IgnoreIndex { get; set; } // 0x14

        [Key(2)]
        public int ConditionValue { get; set; } // 0x18
    }
}
