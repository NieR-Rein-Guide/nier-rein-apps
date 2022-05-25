using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject] // RVA: 0x1C1172C Offset: 0x1C1172C VA: 0x1C1172C
    [MemoryTable("m_event_quest_sequence")] // RVA: 0x1C1172C Offset: 0x1C1172C VA: 0x1C1172C
    public class EntityMEventQuestSequence
    {
        [Key(0)] // RVA: 0x1DD9E54 Offset: 0x1DD9E54 VA: 0x1DD9E54
        public int EventQuestSequenceId { get; set; }
        [Key(1)] // RVA: 0x1DD9E94 Offset: 0x1DD9E94 VA: 0x1DD9E94
        public int SortOrder { get; set; }
        [Key(2)] // RVA: 0x1DD9ED4 Offset: 0x1DD9ED4 VA: 0x1DD9ED4
        public int QuestId { get; set; }
	}
}
