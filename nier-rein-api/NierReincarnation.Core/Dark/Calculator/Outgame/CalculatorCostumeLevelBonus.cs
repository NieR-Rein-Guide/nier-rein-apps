using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorCostumeLevelBonus
    {
        public static readonly int kStatusDataListCapacity = 2; // 0x0
        private static readonly int kUnReleasedCostumeBonusLevel = 0; // 0x4
        private static readonly int kEmptyEffectValue = 0; // 0x8
        public static readonly StatusValue kDefaultCostumeBonusLevelStatus = new StatusValue(kEmptyEffectValue, kEmptyEffectValue, kEmptyEffectValue, kEmptyEffectValue, 0, kEmptyEffectValue, kEmptyEffectValue); // 0xC

        public static void CreateCostumeLevelBonusStatusList(long userId, int characterId, List<DataCostumeLevelBonusStatus> dataCostumeLevelBonusStatusList)
        {
            CalculatorDataCostumeLevelBonus.CreateCostumeLevelBonusStatusList(userId, characterId, dataCostumeLevelBonusStatusList);
        }
    }
}
