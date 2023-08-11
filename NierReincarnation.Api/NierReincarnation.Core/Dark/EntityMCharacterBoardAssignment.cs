using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_assignment")]
    public class EntityMCharacterBoardAssignment
    {
        [Key(0)]
        public int CharacterId { get; set; }

        [Key(1)]
        public int CharacterBoardCategoryId { get; set; }

        [Key(2)]
        public int SortOrder { get; set; }

        [Key(3)]
        public CharacterBoardAssignmentType CharacterBoardAssignmentType { get; set; }
    }
}
