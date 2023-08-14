using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_portal_cage_gate")]
public class EntityMPortalCageGate
{
    [Key(0)]
    public int PortalCageGateId { get; set; }

    [Key(1)]
    public int GatePositionIndex { get; set; }

    [Key(2)]
    public int PortalCageAccessPointFunctionGroupScheduleId { get; set; }
}
