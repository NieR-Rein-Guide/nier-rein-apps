using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_character_board")]
    public class EntityIUserCharacterBoard
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int CharacterBoardId { get; set; } // 0x18

        [Key(2)]
        public int PanelReleaseBit1 { get; set; } // 0x1C

        [Key(3)]
        public int PanelReleaseBit2 { get; set; } // 0x20

        [Key(4)]
        public int PanelReleaseBit3 { get; set; } // 0x24

        [Key(5)]
        public int PanelReleaseBit4 { get; set; } // 0x28

        [Key(6)]
        public long LatestVersion { get; set; } // 0x30
    }
}
