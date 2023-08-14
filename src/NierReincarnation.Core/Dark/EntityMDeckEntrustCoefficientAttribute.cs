using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_deck_entrust_coefficient_attribute")]
public class EntityMDeckEntrustCoefficientAttribute
{
    [Key(0)]
    public int EntrustAttributeType { get; set; }

    [Key(1)]
    public int AttributeType { get; set; }

    [Key(2)]
    public int CoefficientPermil { get; set; }
}