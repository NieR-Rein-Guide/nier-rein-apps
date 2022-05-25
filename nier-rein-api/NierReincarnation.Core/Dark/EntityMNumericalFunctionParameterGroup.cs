using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_numerical_function_parameter_group")]
    public class EntityMNumericalFunctionParameterGroup
    {
        [Key(0)] // RVA: 0x1DDFDB4 Offset: 0x1DDFDB4 VA: 0x1DDFDB4
        public int NumericalFunctionParameterGroupId { get; set; }
        [Key(1)] // RVA: 0x1DDFE1C Offset: 0x1DDFE1C VA: 0x1DDFE1C
        public int ParameterIndex { get; set; }
        [Key(2)] // RVA: 0x1DDFE5C Offset: 0x1DDFE5C VA: 0x1DDFE5C
        public int ParameterValue { get; set; }
	}
}
