using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMNumericalFunctionParameterGroup))]
public class EntityMNumericalFunctionParameterGroup
{
    [Key(0)]
    public int NumericalFunctionParameterGroupId { get; set; }

    [Key(1)]
    public int ParameterIndex { get; set; }

    [Key(2)]
    public int ParameterValue { get; set; }
}
