using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_portal_cage_access_point_function_group_schedule")]
public class EntityMPortalCageAccessPointFunctionGroupSchedule
{
    [Key(0)]
    public int PortalCageAccessPointFunctionGroupScheduleId { get; set; }

    [Key(1)]
    public int PriorityDesc { get; set; }

    [Key(2)]
    public int AccessPointType { get; set; }

    [Key(3)]
    public int AccessPointFunctionGroupId { get; set; }

    [Key(4)]
    public long StartDatetime { get; set; }

    [Key(5)]
    public long EndDatetime { get; set; }
}
