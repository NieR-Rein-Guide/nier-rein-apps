using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserGimmick))]
public class EntityIUserGimmick
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int GimmickSequenceScheduleId { get; set; }

    [Key(2)]
    public int GimmickSequenceId { get; set; }

    [Key(3)]
    public int GimmickId { get; set; }

    [Key(4)]
    public bool IsGimmickCleared { get; set; }

    [Key(5)]
    public long StartDatetime { get; set; }

    [Key(6)]
    public long LatestVersion { get; set; }
}
