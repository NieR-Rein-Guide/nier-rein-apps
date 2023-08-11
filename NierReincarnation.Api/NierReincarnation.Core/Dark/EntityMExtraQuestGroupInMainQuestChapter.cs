using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_extra_quest_group_in_main_quest_chapter")]
public class EntityMExtraQuestGroupInMainQuestChapter
{
    [Key(0)]
    public int MainQuestChapterId { get; set; }

    [Key(1)]
    public int ExtraQuestIndex { get; set; }

    [Key(2)]
    public int ExtraQuestId { get; set; }
}
