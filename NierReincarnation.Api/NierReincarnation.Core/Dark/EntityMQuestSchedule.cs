using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_schedule")]
    public class EntityMQuestSchedule
    {
        [Key(0)] // RVA: 0x1DDF698 Offset: 0x1DDF698 VA: 0x1DDF698
        public int QuestScheduleId { get; set; }

        [Key(1)] // RVA: 0x1DDF6D8 Offset: 0x1DDF6D8 VA: 0x1DDF6D8
        public string QuestScheduleCronExpression { get; set; }

        [Key(2)] // RVA: 0x1DDF6EC Offset: 0x1DDF6EC VA: 0x1DDF6EC
        public long StartDatetime { get; set; }

        [Key(3)] // RVA: 0x1DDF700 Offset: 0x1DDF700 VA: 0x1DDF700
        public long EndDatetime { get; set; }
    }
}
