using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_portal_cage_access_point_function_group_schedule")]
    public class EntityMPortalCageAccessPointFunctionGroupSchedule
    {
        [Key(0)]
        public int PortalCageAccessPointFunctionGroupScheduleId { get; set; } // 0x10
        [Key(1)]
        public int PriorityDesc { get; set; } // 0x14
        [Key(2)]
        public int AccessPointType { get; set; } // 0x18
        [Key(3)]
        public int AccessPointFunctionGroupId { get; set; } // 0x1C
        [Key(4)]
        public long StartDatetime { get; set; } // 0x20
        [Key(5)]
        public long EndDatetime { get; set; } // 0x28
    }
}