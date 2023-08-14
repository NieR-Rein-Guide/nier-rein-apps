using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_numerical_function_parameter_group")]
public class EntityMNumericalFunctionParameterGroup
{
    [Key(0)]
    public int NumericalFunctionParameterGroupId { get; set; }

    [Key(1)]
    public int ParameterIndex { get; set; }

    [Key(2)]
    public int ParameterValue { get; set; }
}
