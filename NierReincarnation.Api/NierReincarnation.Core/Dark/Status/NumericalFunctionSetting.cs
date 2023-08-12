using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status;

// Dark.Status.NumericalFunctionSetting
public class NumericalFunctionSetting
{
    public int BaseValue { get; set; }

    public NumericalFunctionType NumericalFunctionType { get; set; }

    public int[] FunctionParameters { get; set; }
}
