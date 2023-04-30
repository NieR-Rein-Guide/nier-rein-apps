using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_condition_detail")]
    public class EntityMCharacterBoardConditionDetail
    {
        [Key(0)]
        public int CharacterBoardConditionDetailId { get; set; } // 0x10

        [Key(1)]
        public int DetailIndex { get; set; } // 0x14

        [Key(2)]
        public int ConditionValue { get; set; } // 0x18
    }
}
