using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_gimmick_group_event_log")]
public class EntityMGimmickGroupEventLog
{
    [Key(0)]
    public int GimmickGroupId { get; set; }

    [Key(1)]
    public int EventLogTextId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }
}
