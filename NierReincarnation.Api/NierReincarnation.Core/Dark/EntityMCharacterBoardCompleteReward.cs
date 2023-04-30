using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_complete_reward")]
    public class EntityMCharacterBoardCompleteReward
    {
        [Key(0)]
        public int CharacterBoardCompleteRewardId { get; set; } // 0x10

        [Key(1)]
        public int CharacterBoardCompleteRewardGroupId { get; set; } // 0x14

        [Key(2)]
        public int CharacterBoardCompleteRewardConditionGroupId { get; set; } // 0x18
    }
}
