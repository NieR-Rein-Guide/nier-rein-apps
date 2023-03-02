using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board")]
    public class EntityMCharacterBoard
    {
        [Key(0)]
        public int CharacterBoardId { get; set; } // 0x10
        [Key(1)]
        public int CharacterBoardGroupId { get; set; } // 0x14
        [Key(2)]
        public int CharacterBoardUnlockConditionGroupId { get; set; } // 0x18
        [Key(3)]
        public int ReleaseRank { get; set; } // 0x1C
    }
}