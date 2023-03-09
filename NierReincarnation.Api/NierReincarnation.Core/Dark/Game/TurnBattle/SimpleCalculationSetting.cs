using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle
{
    public class SimpleCalculationSetting
    {
        public NumericalFunctionType FunctionType { get; set; } // 0x10
        public int[] FunctionParameters { get; set; }   // 0x18
    }
}
