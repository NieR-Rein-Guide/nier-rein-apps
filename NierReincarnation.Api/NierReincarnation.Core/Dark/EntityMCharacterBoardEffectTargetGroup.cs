using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_effect_target_group")]
    public class EntityMCharacterBoardEffectTargetGroup
    {
        [Key(0)]
        public int CharacterBoardEffectTargetGroupId { get; set; } // 0x10

        [Key(1)]
        public int GroupIndex { get; set; } // 0x14

        [Key(2)]
        public int CharacterBoardEffectTargetType { get; set; } // 0x18

        [Key(3)]
        public int TargetValue { get; set; } // 0x1C
    }
}
