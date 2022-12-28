using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_panel_release_effect_group")]
    public class EntityMCharacterBoardPanelReleaseEffectGroup
    {
        [Key(0)]
        public int CharacterBoardPanelReleaseEffectGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public CharacterBoardEffectType CharacterBoardEffectType { get; set; } // 0x18
        [Key(3)]
        public int CharacterBoardEffectId { get; set; } // 0x1C
        [Key(4)]
        public int EffectValue { get; set; } // 0x20
    }
}