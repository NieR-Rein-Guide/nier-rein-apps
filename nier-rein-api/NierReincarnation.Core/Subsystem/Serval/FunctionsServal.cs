using System;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Subsystem.Serval
{
    // Subsystem.Serval.FunctionsServal
    class FunctionsServal
    {
        public static int calcParameter(NumericalFunctionType functionType, int[] functionParameters, int[] conditionParameters)
        {
            switch (functionType)
            {
                case NumericalFunctionType.LINEAR:
                    return calcLinear(conditionParameters[0], functionParameters);

                case NumericalFunctionType.MONOMIAL:
                    return calcMonomial(conditionParameters[0], functionParameters);

                case NumericalFunctionType.DUPLEX_LINEAR:
                    return calcDuplexLiner(conditionParameters[0], conditionParameters[1], functionParameters);

                case NumericalFunctionType.LINEAR_PERMIL:
                    return calcLinearPermil(conditionParameters[0], functionParameters);

                case NumericalFunctionType.POLYNOMIAL_THIRD:
                    return calcPolynomialThird(conditionParameters[0], functionParameters);

                case NumericalFunctionType.POLYNOMIAL_THIRD_PERMIL:
                    return calcPolynomialThirdPermil(conditionParameters[0], functionParameters);

                case NumericalFunctionType.PARTS_MAIN_OPTION:
                    return calcPartsMainOption(conditionParameters[0], functionParameters);

                default:
                    return 0;
            }
        }

        public static int calcLinear(int value, int[] functionParameters)
        {
            return functionParameters[1] + functionParameters[0] * value;
        }

        public static int calcLinearPermil(int value, int[] functionParameters)
        {
            return functionParameters[0] * value / 1000 +
                   functionParameters[1];
        }

        public static int calcDuplexLiner(int x, int y, int[] functionParameters)
        {
            return functionParameters[0] * x + functionParameters[1] * y;
        }

        public static int calcMonomial(int value, int[] functionParameters)
        {
            value--;
            var value2 = value;

            var counter = functionParameters[1];
            if (counter > 1)
            {
                counter--;
                do
                {
                    counter--;
                    value2 *= value;
                } while (counter != 0);
            }

            return value2 * functionParameters[0];
        }

        public static int calcPolynomialThird(int value, int[] functionParameters)
        {
            return functionParameters[3] + (functionParameters[2] + (functionParameters[1] + functionParameters[0] * value) * value) * value;
        }

        public static int calcPolynomialThirdPermil(int value, int[] functionParameters)
        {
            return functionParameters[0] * value * value * value / 1000 +
                   functionParameters[1] * value * value / 1000 +
                   functionParameters[2] * value / 1000 +
                   functionParameters[3];
        }

        public static int calcPartsMainOption(int value, int[] functionParameters)
        {
            var poly0 = Math.Min(13, (int)((value - 1) & (value - 1) >> 31 ^ 0xFFFFFFFF));
            poly0 = functionParameters[0] * poly0 / 1000;

            var poly1 = Math.Min(1, (int)((value - 14) & (value - 14) >> 31 ^ 0xFFFFFFFF));
            poly1 = functionParameters[1] * poly1;

            return poly0 + poly1;
        }
    }
}
