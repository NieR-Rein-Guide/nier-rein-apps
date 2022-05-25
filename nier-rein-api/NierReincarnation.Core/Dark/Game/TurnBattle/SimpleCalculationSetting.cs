using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle
{
    public class SimpleCalculationSetting
    {
        public NumericalFunctionType FunctionType { get; set; }
        public int[] FunctionParameters { get; set; }   // 0x18
    }
}
