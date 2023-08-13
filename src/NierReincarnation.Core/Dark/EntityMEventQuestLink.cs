using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_link")]
public class EntityMEventQuestLink
{
    [Key(0)]
    public int EventQuestLinkId { get; set; }

    [Key(1)]
    public DomainType DestinationDomainType { get; set; }

    [Key(2)]
    public int DestinationDomainId { get; set; }

    [Key(3)]
    public PossessionType PossessionType { get; set; }

    [Key(4)]
    public int PossessionId { get; set; }
}
