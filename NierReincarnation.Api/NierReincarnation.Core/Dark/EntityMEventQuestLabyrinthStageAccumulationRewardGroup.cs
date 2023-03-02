using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_labyrinth_stage_accumulation_reward_group")]
    public class EntityMEventQuestLabyrinthStageAccumulationRewardGroup
    {
        [Key(0)]
        public int EventQuestLabyrinthStageAccumulationRewardGroupId { get; set; } // 0x10
        [Key(1)]
        public int QuestMissionClearCount { get; set; } // 0x14
        [Key(2)]
        public int EventQuestLabyrinthRewardGroupId { get; set; } // 0x18
    }
}