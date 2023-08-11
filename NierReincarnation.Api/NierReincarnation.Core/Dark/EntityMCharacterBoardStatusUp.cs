using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_status_up")]
    public class EntityMCharacterBoardStatusUp
    {
        [Key(0)]
        public int CharacterBoardStatusUpId { get; set; }

        [Key(1)]
        public CharacterBoardStatusUpType CharacterBoardStatusUpType { get; set; }

        [Key(2)]
        public int CharacterBoardEffectTargetGroupId { get; set; }
    }
}
