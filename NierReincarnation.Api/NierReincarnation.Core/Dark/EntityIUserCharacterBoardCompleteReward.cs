using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_character_board_complete_reward")]
    public class EntityIUserCharacterBoardCompleteReward
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int CharacterBoardCompleteRewardId { get; set; }

        [Key(2)]
        public long LatestVersion { get; set; }
    }
}
