using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_group")]
    public class EntityMCharacterBoardGroup
    {
        [Key(0)]
        public int CharacterBoardGroupId { get; set; }

        [Key(1)]
        public int CharacterBoardCategoryId { get; set; }

        [Key(2)]
        public int SortOrder { get; set; }

        [Key(3)]
        public CharacterBoardGroupType CharacterBoardGroupType { get; set; }

        [Key(4)]
        public int TextAssetId { get; set; }
    }
}
