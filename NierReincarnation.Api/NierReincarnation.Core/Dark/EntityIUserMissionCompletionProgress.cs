using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_mission_completion_progress")]
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
