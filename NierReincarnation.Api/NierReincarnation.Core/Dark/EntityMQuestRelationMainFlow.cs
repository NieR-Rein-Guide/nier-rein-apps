using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_relation_main_flow")]
    public class EntityMQuestRelationMainFlow
    {
        [Key(0)]
        public int MainFlowQuestId { get; set; }

        [Key(1)]
        public DifficultyType DifficultyType { get; set; }

        [Key(2)]
        public int ReplayFlowQuestId { get; set; }

        [Key(3)]
        public int SubFlowQuestId { get; set; }
    }
}
