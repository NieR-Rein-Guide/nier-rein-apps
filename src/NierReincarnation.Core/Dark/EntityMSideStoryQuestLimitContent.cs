using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSideStoryQuestLimitContent))]
public class EntityMSideStoryQuestLimitContent
{
    [Key(0)]
    public int SideStoryQuestLimitContentId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int EventQuestChapterId { get; set; }

    [Key(3)]
    public DifficultyType DifficultyType { get; set; }

    [Key(4)]
    public int NextSideStoryQuestId { get; set; }
}
