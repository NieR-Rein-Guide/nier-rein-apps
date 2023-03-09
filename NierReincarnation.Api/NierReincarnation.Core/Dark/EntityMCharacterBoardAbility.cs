using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_ability")]
    public class EntityMCharacterBoardAbility
    {
        [Key(0)]
        public int CharacterBoardAbilityId { get; set; } // 0x10
        [Key(1)]
        public int CharacterBoardEffectTargetGroupId { get; set; } // 0x14
        [Key(2)]
        public int AbilityId { get; set; } // 0x18
    }
}