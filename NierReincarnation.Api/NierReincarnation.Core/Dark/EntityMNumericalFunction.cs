using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_numerical_function")]
public class EntityMNumericalFunction
{
    [Key(0)] // RVA: 0x1DDFD4C Offset: 0x1DDFD4C VA: 0x1DDFD4C
    public int NumericalFunctionId { get; set; }

    [Key(1)] // RVA: 0x1DDFD8C Offset: 0x1DDFD8C VA: 0x1DDFD8C
    public NumericalFunctionType NumericalFunctionType { get; set; }

    [Key(2)] // RVA: 0x1DDFDA0 Offset: 0x1DDFDA0 VA: 0x1DDFDA0
    public int NumericalFunctionParameterGroupId { get; set; }
}
