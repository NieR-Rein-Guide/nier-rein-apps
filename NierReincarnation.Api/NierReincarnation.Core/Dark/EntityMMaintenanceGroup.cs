using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_maintenance_group")]
    public class EntityMMaintenanceGroup
    {
        [Key(0)]
        public int MaintenanceGroupId { get; set; }

        [Key(1)]
        public string ApiPath { get; set; }

        [Key(2)]
        public int Priority { get; set; }

        [Key(3)]
        public int ScreenTransitionType { get; set; }

        [Key(4)]
        public MaintenanceBlockFunctionType BlockFunctionType { get; set; }

        [Key(5)]
        public string BlockFunctionValue { get; set; }
    }
}
