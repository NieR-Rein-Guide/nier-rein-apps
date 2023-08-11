using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_gimmick_sequence")]
public class EntityIUserGimmickSequence
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int GimmickSequenceScheduleId { get; set; }

    [Key(2)]
    public int GimmickSequenceId { get; set; }

    [Key(3)]
    public bool IsGimmickSequenceCleared { get; set; }

    [Key(4)]
    public long ClearDatetime { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
