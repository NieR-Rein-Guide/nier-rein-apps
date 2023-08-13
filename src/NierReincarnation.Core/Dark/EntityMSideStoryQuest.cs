using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_side_story_quest")]
public class EntityMSideStoryQuest
{
    [Key(0)]
    public int SideStoryQuestId { get; set; }

    [Key(1)]
    public int SideStoryQuestType { get; set; }

    [Key(2)]
    public int TargetId { get; set; }
}
