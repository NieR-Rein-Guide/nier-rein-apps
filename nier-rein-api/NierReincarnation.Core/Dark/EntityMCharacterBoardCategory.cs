using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_category")]
    public class EntityMCharacterBoardCategory
    {
        [Key(0)]
        public int CharacterBoardCategoryId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
    }
}