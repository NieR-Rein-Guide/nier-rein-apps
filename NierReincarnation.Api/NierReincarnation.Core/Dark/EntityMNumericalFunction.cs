using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_numerical_function")]
public class EntityMNumericalFunction
{
    [Key(0)]
    public int NumericalFunctionId { get; set; }

    [Key(1)]
    public NumericalFunctionType NumericalFunctionType { get; set; }

    [Key(2)]
    public int NumericalFunctionParameterGroupId { get; set; }
}
