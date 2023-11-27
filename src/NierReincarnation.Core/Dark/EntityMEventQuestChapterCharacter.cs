using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestChapterCharacter))]
public class EntityMEventQuestChapterCharacter
{
    [Key(0)]
    public int EventQuestChapterId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }
}
