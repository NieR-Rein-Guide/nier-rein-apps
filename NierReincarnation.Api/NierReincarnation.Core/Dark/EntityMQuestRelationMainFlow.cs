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
        public int MainFlowQuestId { get; set; } // 0x10

        [Key(1)]
        public DifficultyType DifficultyType { get; set; } // 0x14

        [Key(2)]
        public int ReplayFlowQuestId { get; set; } // 0x18

        [Key(3)]
        public int SubFlowQuestId { get; set; } // 0x1C
    }
}
