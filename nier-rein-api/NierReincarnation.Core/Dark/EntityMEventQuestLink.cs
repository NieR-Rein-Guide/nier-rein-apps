using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject] // RVA: 0x1C116DC Offset: 0x1C116DC VA: 0x1C116DC
    [MemoryTable("m_event_quest_link")] // RVA: 0x1C116DC Offset: 0x1C116DC VA: 0x1C116DC
    public class EntityMEventQuestLink
    {
        [Key(0)] // RVA: 0x1DD9DC4 Offset: 0x1DD9DC4 VA: 0x1DD9DC4
        public int EventQuestLinkId { get; set; }
        [Key(1)] // RVA: 0x1DD9E04 Offset: 0x1DD9E04 VA: 0x1DD9E04
        public int DestinationDomainType { get; set; }
        [Key(2)] // RVA: 0x1DD9E18 Offset: 0x1DD9E18 VA: 0x1DD9E18
        public int DestinationDomainId { get; set; }
        [Key(3)] // RVA: 0x1DD9E2C Offset: 0x1DD9E2C VA: 0x1DD9E2C
        public int PossessionType { get; set; }
        [Key(4)] // RVA: 0x1DD9E40 Offset: 0x1DD9E40 VA: 0x1DD9E40
        public int PossessionId { get; set; }
	}
}
