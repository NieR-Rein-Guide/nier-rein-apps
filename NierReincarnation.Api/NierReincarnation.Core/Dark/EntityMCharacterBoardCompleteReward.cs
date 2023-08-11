using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_board_complete_reward")]
    public class EntityMCharacterBoardCompleteReward
    {
        [Key(0)]
        public int CharacterBoardCompleteRewardId { get; set; }

        [Key(1)]
        public int CharacterBoardCompleteRewardGroupId { get; set; }

        [Key(2)]
        public int CharacterBoardCompleteRewardConditionGroupId { get; set; }
    }
}
