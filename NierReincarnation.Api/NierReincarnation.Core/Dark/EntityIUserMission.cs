using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_mission")]
public class EntityIUserMission
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int MissionId { get; set; }

    [Key(2)]
    public long StartDatetime { get; set; }

    [Key(3)]
    public int ProgressValue { get; set; }

    [Key(4)]
    public MissionProgressStatusType MissionProgressStatusType { get; set; }

    [Key(5)]
    public long ClearDatetime { get; set; }

    [Key(6)]
    public long LatestVersion { get; set; }
}
