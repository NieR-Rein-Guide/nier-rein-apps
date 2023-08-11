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
        public PossessionType PossessionType { get; set; }

        [Key(1)]
        public int PossessionId { get; set; }

        [Key(2)]
        public int SortOrder { get; set; }

        [Key(3)]
        public int AcquisitionRouteType { get; set; }

        [Key(4)]
        public int RouteId { get; set; }

        [Key(5)]
        public string RelationValue { get; set; }

        [Key(6)]
        public long StartDatetime { get; set; }

        [Key(7)]
        public long EndDatetime { get; set; }
    }
}
