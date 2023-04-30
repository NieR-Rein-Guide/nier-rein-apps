using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_chapter_character")]
    public class EntityMEventQuestChapterCharacter
    {
        [Key(0)] // RVA: 0x1DD9F5C Offset: 0x1DD9F5C VA: 0x1DD9F5C
        public int EventQuestChapterId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD9F9C Offset: 0x1DD9F9C VA: 0x1DD9F9C
        public int CharacterId { get; set; } // 0x14
    }
}
