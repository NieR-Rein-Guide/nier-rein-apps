using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMExtraQuestGroupInMainQuestChapter))]
public class EntityMExtraQuestGroupInMainQuestChapter
{
    [Key(0)]
    public int MainQuestChapterId { get; set; }

    [Key(1)]
    public int ExtraQuestIndex { get; set; }

    [Key(2)]
    public int ExtraQuestId { get; set; }
}
