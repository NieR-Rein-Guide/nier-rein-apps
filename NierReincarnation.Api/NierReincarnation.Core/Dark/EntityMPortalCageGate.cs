using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_portal_cage_gate")]
    public class EntityMPortalCageGate
    {
        [Key(0)]
        public int PortalCageGateId { get; set; } // 0x10

        [Key(1)]
        public int GatePositionIndex { get; set; } // 0x14

        [Key(2)]
        public int PortalCageAccessPointFunctionGroupScheduleId { get; set; } // 0x18
    }
}
