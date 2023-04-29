using NierReincarnation.Core.Dark.Status;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Calculator
{
    public static class CalculatorDataCostumeProperAttributeBonusStatus
    {
        public static int GetCostumeProperAttributeHpAdditionalValue(int costumeId, DataWeaponStatus mainWeapon, List<DataWeaponStatus> subWeapons)
        {
            var result = 0;
            if (DatabaseDefine.Master.EntityMCostumeProperAttributeHpBonusTable.TryFindByCostumeId(costumeId, out var costumeProperAttributeHpBonus))
            {
                if (mainWeapon.AttributeType == costumeProperAttributeHpBonus.CostumeProperAttributeType)
                {
                    result += costumeProperAttributeHpBonus.MainWeaponHpAdditionalValue;
                }

                foreach (var subWeapon in subWeapons)
                {
                    if (subWeapon.AttributeType == costumeProperAttributeHpBonus.CostumeProperAttributeType)
                    {
                        result += costumeProperAttributeHpBonus.SubWeaponHpAdditionalValue;
                    }
                }
            }

            return result;
        }
    }
}
