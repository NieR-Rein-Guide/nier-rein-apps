using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_side_story_quest")]
public class EntityIUserSideStoryQuest
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int SideStoryQuestId { get; set; }

    [Key(2)]
    public int HeadSideStoryQuestSceneId { get; set; }

    [Key(3)]
    public int SideStoryQuestStateType { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
