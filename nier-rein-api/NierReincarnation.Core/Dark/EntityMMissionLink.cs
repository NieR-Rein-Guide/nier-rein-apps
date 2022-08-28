using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_link")]
    public class EntityMMissionLink
    {
        [Key(0)]
        public int MissionLinkId { get; set; } // 0x10
        [Key(1)]
        public int DestinationDomainType { get; set; } // 0x14
        [Key(2)]
        public int DestinationDomainId { get; set; } // 0x18
    }
}