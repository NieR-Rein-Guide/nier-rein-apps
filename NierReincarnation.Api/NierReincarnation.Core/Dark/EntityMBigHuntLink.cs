using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_link")]
    public class EntityMBigHuntLink
    {
        [Key(0)]
        public int BigHuntLinkId { get; set; } // 0x10

        [Key(1)]
        public DomainType DestinationDomainType { get; set; } // 0x14

        [Key(2)]
        public int DestinationDomainId { get; set; } // 0x18

        [Key(3)]
        public PossessionType PossessionType { get; set; } // 0x1C

        [Key(4)]
        public int PossessionId { get; set; } // 0x20
    }
}
