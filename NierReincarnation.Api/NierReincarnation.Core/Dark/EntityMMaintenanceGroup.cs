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
        public int MaintenanceGroupId { get; set; } // 0x10

        [Key(1)]
        public string ApiPath { get; set; } // 0x18

        [Key(2)]
        public int Priority { get; set; } // 0x20

        [Key(3)]
        public int ScreenTransitionType { get; set; } // 0x24

        [Key(4)]
        public MaintenanceBlockFunctionType BlockFunctionType { get; set; } // 0x28

        [Key(5)]
        public string BlockFunctionValue { get; set; } // 0x30
    }
}
