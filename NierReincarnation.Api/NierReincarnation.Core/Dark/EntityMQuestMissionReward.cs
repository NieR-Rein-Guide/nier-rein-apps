using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_mission_reward")]
    public class EntityMQuestMissionReward
    {
        [Key(0)]
        public int QuestMissionRewardId { get; set; }

        [Key(1)]
        public PossessionType PossessionType { get; set; }

        [Key(2)]
        public int PossessionId { get; set; }

        [Key(3)]
        public int Count { get; set; }
    }
}
