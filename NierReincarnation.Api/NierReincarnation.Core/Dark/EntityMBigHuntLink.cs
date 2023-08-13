using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_big_hunt_link")]
public class EntityMBigHuntLink
{
    [Key(0)]
    public int BigHuntLinkId { get; set; }

    [Key(1)]
    public DomainType DestinationDomainType { get; set; }

    [Key(2)]
    public int DestinationDomainId { get; set; }

    [Key(3)]
    public PossessionType PossessionType { get; set; }

    [Key(4)]
    public int PossessionId { get; set; }
}
