using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_guerrilla_free_open_schedule_correspondence")]
    public class EntityMEventQuestGuerrillaFreeOpenScheduleCorrespondence
    {
        [Key(0)]
        public int QuestId { get; set; } // 0x10
        [Key(1)]
        public int QuestScheduleId { get; set; } // 0x14
    }
}