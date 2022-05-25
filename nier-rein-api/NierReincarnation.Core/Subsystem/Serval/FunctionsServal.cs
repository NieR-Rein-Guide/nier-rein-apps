using System;
using System.Numerics;
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
            throw new NotImplementedException();

            /*    iVar4 = Subsystem.Serval.Array<int>$$get_Item
                                    (&uStack40,0,Method$Subsystem.Serval.Array<int>.get_Item());
                  iVar5 = Subsystem.Serval.Array<int>$$get_Item
                                    (&uStack40,1,Method$Subsystem.Serval.Array<int>.get_Item());
                  uVar3 = param_1 - 1;
                  uVar1 = uVar3 & ((int)uVar3 >> 0x1f ^ 0xffffffffU);
                  if (0xd < (int)uVar3) {
                    uVar1 = 0xd;
                  }
                  uVar3 = param_1 - 0xe;
                  auVar2 = SEXT816((long)((long)iVar4 * (ulong)uVar1)) * SEXT816(0x20c49ba5e353f7cf);
                  uVar1 = uVar3 & ((int)uVar3 >> 0x1f ^ 0xffffffffU);
                  if (1 < (int)uVar3) {
                    uVar1 = 1;
                  }
                  return ((int)SUB168(auVar2 >> 0x47,0) - SUB164(auVar2 >> 0x7f,0)) + iVar5 * uVar1;*/
            return 0;
        }
    }
}
