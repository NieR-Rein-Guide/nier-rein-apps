using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserMissionCompletionProgress))]
public class EntityIUserMissionCompletionProgress
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int MissionId { get; set; }

    [Key(2)]
    public long ProgressValue { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
