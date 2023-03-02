using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_numerical_parameter_map")]
    public class EntityMNumericalParameterMap
    {
        [Key(0)]
        public int NumericalParameterMapId { get; set; } // 0x10
        [Key(1)]
        public int ParameterKey { get; set; } // 0x14
        [Key(2)]
        public int ParameterValue { get; set; } // 0x18
    }
}