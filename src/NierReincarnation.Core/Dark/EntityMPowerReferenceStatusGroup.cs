using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_power_reference_status_group")]
public class EntityMPowerReferenceStatusGroup
{
    [Key(0)]
    public int PowerReferenceStatusGroupId { get; set; }

    [Key(1)]
    public StatusKindType ReferenceStatusType { get; set; }

    [Key(2)]
    public AttributeConditionType AttributeConditionType { get; set; }

    [Key(3)]
    public int CoefficientValuePermil { get; set; }
}
