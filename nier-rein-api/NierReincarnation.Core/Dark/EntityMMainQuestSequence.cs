using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_main_quest_sequence")]
    public class EntityMMainQuestSequence
    {
        [Key(0)] // RVA: 0x1DDBD6C Offset: 0x1DDBD6C VA: 0x1DDBD6C
        public int MainQuestSequenceId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DDBDAC Offset: 0x1DDBDAC VA: 0x1DDBDAC
        public int SortOrder { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DDBDEC Offset: 0x1DDBDEC VA: 0x1DDBDEC
        public int QuestId { get; set; } // 0x18
	}
}
