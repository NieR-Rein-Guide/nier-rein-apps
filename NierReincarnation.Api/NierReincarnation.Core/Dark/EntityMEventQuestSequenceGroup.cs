using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject] // RVA: 0x1C1177C Offset: 0x1C1177C VA: 0x1C1177C
    [MemoryTable("m_event_quest_sequence_group")] // RVA: 0x1C1177C Offset: 0x1C1177C VA: 0x1C1177C
    public class EntityMEventQuestSequenceGroup
    {
        // Properties
        [Key(0)] // RVA: 0x1DD9EE8 Offset: 0x1DD9EE8 VA: 0x1DD9EE8
        public int EventQuestSequenceGroupId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD9F28 Offset: 0x1DD9F28 VA: 0x1DD9F28
        public DifficultyType DifficultyType { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DD9F68 Offset: 0x1DD9F68 VA: 0x1DD9F68
        public int EventQuestSequenceId { get; set; } // 0x18
    }
}
