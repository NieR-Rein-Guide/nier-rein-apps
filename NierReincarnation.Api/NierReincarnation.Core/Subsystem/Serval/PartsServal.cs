using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Subsystem.Serval
{
    public static class PartsServal
    {
        public static readonly int SUB_STATUS_MAX_COUNT = 4; // 0x0
        public static readonly int SUB_STATUS_ENHANCE_WIDTH_LEVEL = 3; // 0x4
        public static readonly int MAX_LEVEL = 15; // 0x8
        public static readonly int MAX_SELL_COUNT = 20; // 0xC
        public static readonly int PRESET_MAX_NUMBER = 30; // 0x10
        public static readonly int PRESET_TAG_MAX_NUMBER = 6; // 0x14

        public static int calcSellPrice(int currentLevel, NumericalFunctionType functionType, int[] functionParameters)
        {
            return FunctionsServal.calcParameter(functionType, functionParameters, new[] { currentLevel });
        }

        public static int calcStatusDiffByMainOption(int level, int baseValue, NumericalFunctionType functionType, int[] functionParameters)
        {
            return baseValue + FunctionsServal.calcParameter(functionType, functionParameters, new[] { level });
        }
    }
}
