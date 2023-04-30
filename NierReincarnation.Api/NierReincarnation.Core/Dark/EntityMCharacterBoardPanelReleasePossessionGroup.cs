using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_panel_release_possession_group")]
    public class EntityMCharacterBoardPanelReleasePossessionGroup
    {
        [Key(0)]
        public int CharacterBoardPanelReleasePossessionGroupId { get; set; } // 0x10

        [Key(1)]
        public PossessionType PossessionType { get; set; } // 0x14

        [Key(2)]
        public int PossessionId { get; set; } // 0x18

        [Key(3)]
        public int Count { get; set; } // 0x1C

        [Key(4)]
        public int SortOrder { get; set; } // 0x20
    }
}
