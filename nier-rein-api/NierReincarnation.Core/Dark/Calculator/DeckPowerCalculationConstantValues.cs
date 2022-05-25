using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Calculator
{
    class DeckPowerCalculationConstantValues
    {
        private static DeckPowerCalculationConstantValues _instance; // 0x0

        public static DeckPowerCalculationConstantValues Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = new DeckPowerCalculationConstantValues();
                _instance.Setup();

                return _instance;
            }
        }

        public int CostumePowerAttackCoefficientPermil { get; set; }    // 0x10
        public int CostumePowerVitalityCoefficientPermil { get; set; }
        public int CostumePowerHpCoefficientPermil { get; set; }
        public int WeaponPowerAttackCoefficientPermil { get; set; }
        public int WeaponPowerVitalityCoefficientPermil { get; set; }   // 0x20
        public int WeaponPowerHpCoefficientPermil { get; set; }
        public int CompanionPowerAttackCoefficientPermil { get; set; }
        public int CompanionPowerVitalityCoefficientPermil { get; set; }
        public int CompanionPowerHpCoefficientPermil { get; set; }  // 0x30
        public int PartsAddPowerAgilityCoefficientPermil { get; set; }
        public int PartsAddPowerAttackCoefficientPermil { get; set; }
        public int PartsAddPowerCriticalAttackCoefficientPermil { get; set; }
        public int PartsAddPowerCriticalRatioCoefficientPermil { get; set; }    // 0x40
        public int PartsAddPowerEvasionRatioCoefficientPermil { get; set; }
        public int PartsAddPowerHpCoefficientPermil { get; set; }
        public int PartsAddPowerVitalityCoefficientPermil { get; set; }
        public int PartsMulPowerAgilityBaseValue { get; set; }  // 0x50
        public int PartsMulPowerAttackBaseValue { get; set; }
        public int PartsMulPowerCriticalAttackBaseValue { get; set; }
        public int PartsMulPowerCriticalRatioBaseValue { get; set; }
        public int PartsMulPowerEvasionRatioBaseValue { get; set; } // 0x60
        public int PartsMulPowerHpBaseValue { get; set; }
        public int PartsMulPowerVitalityBaseValue { get; set; } // 0x68

        public void Setup()
        {
            var table = DatabaseDefine.Master.EntityMPowerCalculationConstantValueTable;

            foreach (var item in table.All)
            {
                switch (item.PowerCalculationConstantValueType)
                {
                    case PowerCalculationConstantValueType.COSTUME_ATTACK_COEFFICIENT:
                        CostumePowerAttackCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.COSTUME_HP_COEFFICIENT:
                        CostumePowerHpCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.COSTUME_VITALITY_COEFFICIENT:
                        CostumePowerVitalityCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.WEAPON_ATTACK_COEFFICIENT:
                        WeaponPowerAttackCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.WEAPON_HP_COEFFICIENT:
                        WeaponPowerHpCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.WEAPON_VITALITY_COEFFICIENT:
                        WeaponPowerVitalityCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.COMPANION_ATTACK_COEFFICIENT:
                        CompanionPowerAttackCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.COMPANION_HP_COEFFICIENT:
                        CompanionPowerHpCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.COMPANION_VITALITY_COEFFICIENT:
                        CompanionPowerVitalityCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_ADD_POWER_AGILITY_COEFFICIENT:
                        PartsAddPowerAgilityCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_ADD_POWER_ATTACK_COEFFICIENT:
                        PartsAddPowerAttackCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_ADD_POWER_CRITICAL_ATTACK_COEFFICIENT:
                        PartsAddPowerCriticalAttackCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_ADD_POWER_CRITICAL_RATIO_COEFFICIENT:
                        PartsAddPowerCriticalRatioCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_ADD_POWER_EVASION_RATIO_COEFFICIENT:
                        PartsAddPowerEvasionRatioCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_ADD_POWER_HP_COEFFICIENT:
                        PartsAddPowerHpCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_ADD_POWER_VITALITY_COEFFICIENT:
                        PartsAddPowerVitalityCoefficientPermil = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_MUL_POWER_AGILITY_BASE_VALUE:
                        PartsMulPowerAgilityBaseValue = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_MUL_POWER_ATTACK_BASE_VALUE:
                        PartsMulPowerAttackBaseValue = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_MUL_POWER_CRITICAL_ATTACK_BASE_VALUE:
                        PartsMulPowerCriticalAttackBaseValue = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_MUL_POWER_CRITICAL_RATIO_BASE_VALUE:
                        PartsMulPowerCriticalRatioBaseValue = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_MUL_POWER_EVASION_RATIO_BASE_VALUE:
                        PartsMulPowerEvasionRatioBaseValue = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_MUL_POWER_HP_BASE_VALUE:
                        PartsMulPowerHpBaseValue = item.ConstantValue;
                        break;

                    case PowerCalculationConstantValueType.PARTS_MUL_POWER_VITALITY_BASE_VALUE:
                        PartsMulPowerVitalityBaseValue = item.ConstantValue;
                        break;
                }
            }
        }
    }
}
