using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_possession_acquisition_route")]
    public class EntityMPossessionAcquisitionRoute
    {
        [Key(0)]
        public PossessionType PossessionType { get; set; } // 0x10
        [Key(1)]
        public int PossessionId { get; set; } // 0x14
        [Key(2)]
        public int SortOrder { get; set; } // 0x18
        [Key(3)]
        public int AcquisitionRouteType { get; set; } // 0x1C
        [Key(4)]
        public int RouteId { get; set; } // 0x20
        [Key(5)]
        public string RelationValue { get; set; } // 0x28
        [Key(6)]
        public long StartDatetime { get; set; } // 0x30
        [Key(7)]
        public long EndDatetime { get; set; } // 0x38
    }
}