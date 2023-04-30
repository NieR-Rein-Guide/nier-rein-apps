using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_release_condition_quest_challenge")]
    public class EntityMQuestReleaseConditionQuestChallenge
    {
        [Key(0)]
        public int QuestReleaseConditionId { get; set; } // 0x10

        [Key(1)]
        public int QuestId { get; set; } // 0x14
    }
}
