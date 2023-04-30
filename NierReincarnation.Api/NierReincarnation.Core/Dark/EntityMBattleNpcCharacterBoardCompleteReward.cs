using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_character_board_complete_reward")]
    public class EntityMBattleNpcCharacterBoardCompleteReward
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)]
        public int CharacterBoardCompleteRewardId { get; set; } // 0x18
    }
}
