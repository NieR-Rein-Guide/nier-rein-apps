using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_season_reward_group")]
    public class EntityMEventQuestLabyrinthSeasonRewardGroup
    {
        [Key(0)]
        public int EventQuestLabyrinthSeasonRewardGroupId { get; set; }

        [Key(1)]
        public int HeadQuestId { get; set; }

        [Key(2)]
        public int EventQuestLabyrinthRewardGroupId { get; set; }
    }
}
