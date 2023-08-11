using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_link")]
    public class EntityMMissionLink
    {
        [Key(0)]
        public int MissionLinkId { get; set; }

        [Key(1)]
        public DomainType DestinationDomainType { get; set; }

        [Key(2)]
        public int DestinationDomainId { get; set; }
    }
}
