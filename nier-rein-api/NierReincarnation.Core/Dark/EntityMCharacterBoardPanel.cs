using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_panel")]
    public class EntityMCharacterBoardPanel
    {
        [Key(0)]
        public int CharacterBoardPanelId { get; set; } // 0x10
        [Key(1)]
        public int CharacterBoardId { get; set; } // 0x14
        [Key(2)]
        public int CharacterBoardPanelUnlockConditionGroupId { get; set; } // 0x18
        [Key(3)]
        public int CharacterBoardPanelReleasePossessionGroupId { get; set; } // 0x1C
        [Key(4)]
        public int CharacterBoardPanelReleaseRewardGroupId { get; set; } // 0x20
        [Key(5)]
        public int CharacterBoardPanelReleaseEffectGroupId { get; set; } // 0x24
        [Key(6)]
        public int SortOrder { get; set; } // 0x28
        [Key(7)]
        public int ParentCharacterBoardPanelId { get; set; } // 0x2C
        [Key(8)]
        public int PlaceIndex { get; set; } // 0x30
    }
}