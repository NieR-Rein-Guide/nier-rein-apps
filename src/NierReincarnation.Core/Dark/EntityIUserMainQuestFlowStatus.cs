using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserMainQuestFlowStatus))]
public class EntityIUserMainQuestFlowStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public QuestFlowType CurrentQuestFlowType { get; set; }

    [Key(2)]
    public long LatestVersion { get; set; }
}
