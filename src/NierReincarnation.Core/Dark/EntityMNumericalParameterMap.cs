using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_numerical_parameter_map")]
public class EntityMNumericalParameterMap
{
    [Key(0)]
    public int NumericalParameterMapId { get; set; }

    [Key(1)]
    public int ParameterKey { get; set; }

    [Key(2)]
    public int ParameterValue { get; set; }
}
