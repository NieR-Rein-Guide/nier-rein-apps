using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_character_board_ability")]
    public class EntityMBattleNpcCharacterBoardAbility
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)]
        public int CharacterId { get; set; } // 0x18

        [Key(2)]
        public int AbilityId { get; set; } // 0x1C

        [Key(3)]
        public int Level { get; set; } // 0x20
    }
}
