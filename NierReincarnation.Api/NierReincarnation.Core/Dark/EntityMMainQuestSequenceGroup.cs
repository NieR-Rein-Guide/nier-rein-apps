using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_main_quest_sequence_group")]
    public class EntityMMainQuestSequenceGroup
    {
        [Key(0)] // RVA: 0x1DDBE00 Offset: 0x1DDBE00 VA: 0x1DDBE00
        public int MainQuestSequenceGroupId { get; set; }

        [Key(1)] // RVA: 0x1DDBE40 Offset: 0x1DDBE40 VA: 0x1DDBE40
        public DifficultyType DifficultyType { get; set; }

        [Key(2)] // RVA: 0x1DDBE80 Offset: 0x1DDBE80 VA: 0x1DDBE80
        public int MainQuestSequenceId { get; set; }
    }
}
