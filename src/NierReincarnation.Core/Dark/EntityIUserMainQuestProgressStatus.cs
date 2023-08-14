using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_main_quest_progress_status")]
public class EntityIUserMainQuestProgressStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CurrentQuestSceneId { get; set; }

    [Key(2)]
    public int HeadQuestSceneId { get; set; }

    [Key(3)]
    public QuestFlowType CurrentQuestFlowType { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}