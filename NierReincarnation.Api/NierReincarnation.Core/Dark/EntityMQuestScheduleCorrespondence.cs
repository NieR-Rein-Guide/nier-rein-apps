using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_schedule_correspondence")]
    public class EntityMQuestScheduleCorrespondence
    {
        [Key(0)] // RVA: 0x1DDF714 Offset: 0x1DDF714 VA: 0x1DDF714
        public int QuestId { get; set; }

        [Key(1)] // RVA: 0x1DDF754 Offset: 0x1DDF754 VA: 0x1DDF754
        public int QuestScheduleId { get; set; }
    }
}
