using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_extra_quest_group")]
    public class EntityMExtraQuestGroup
    {
        [Key(0)]
        public int QuestId { get; set; } // 0x10
        [Key(1)]
        public int ExtraQuestIndex { get; set; } // 0x14
        [Key(2)]
        public int ExtraQuestId { get; set; } // 0x18
    }
}