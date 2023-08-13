using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_chapter_character")]
public class EntityMEventQuestChapterCharacter
{
    [Key(0)]
    public int EventQuestChapterId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }
}
