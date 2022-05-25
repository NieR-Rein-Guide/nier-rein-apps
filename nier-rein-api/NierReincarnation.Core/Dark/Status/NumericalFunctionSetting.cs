using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status
{
    // Dark.Status.NumericalFunctionSetting
    public class NumericalFunctionSetting
    {
        // 0x10
        public int BaseValue { get; set; }
        // 0x14
        public NumericalFunctionType NumericalFunctionType { get; set; }
        // 0x18
        public int[] FunctionParameters { get; set; }
	}
}
