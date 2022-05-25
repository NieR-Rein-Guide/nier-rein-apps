using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark.Calculator
{
    public static class CalculatorStatus
    {
        public static StatusValue CalculateDeckActorStatus(DataCostumeStatus costumeStatus,
            DataCompanionStatus companionStatus, DataWeaponStatus mainWeaponStatus,
            List<DataWeaponStatus> subWeaponStatusList, List<DataPartsMainStatus> partsMainStatusList,
            List<DataPartsSubStatus> partsSubStatusList, List<DataAbilityStatus> abilityStatusList,
            List<DataCharacterBoardStatus> characterBoardStatusList,
            List<DataCostumeLevelBonusStatus> costumeLevelBonusStatusList)
        {
            var statusValue = GetCostumeStatus(costumeStatus, partsMainStatusList, partsSubStatusList, abilityStatusList, characterBoardStatusList, costumeLevelBonusStatusList);

            statusValue += GetWeaponStatus(mainWeaponStatus, abilityStatusList, mainWeaponStatus?.WeaponType == costumeStatus.SkillfulWeaponType, true);

            foreach (var subWeaponStatus in subWeaponStatusList)
            {
                if (subWeaponStatus == null)
                    continue;

                statusValue += GetWeaponStatus(subWeaponStatus, abilityStatusList, subWeaponStatus.WeaponType == costumeStatus.SkillfulWeaponType, false);
            }

            if (companionStatus != null)
                statusValue += GetCompanionStatus(companionStatus, abilityStatusList);

            return statusValue;
        }

        public static StatusValue GetCostumeStatus(DataCostumeStatus costumeStatus,
            List<DataPartsMainStatus> partsMainStatusList, List<DataPartsSubStatus> partsSubStatusList,
            List<DataAbilityStatus> abilityStatusList, List<DataCharacterBoardStatus> characterBoardStatusList,
            List<DataCostumeLevelBonusStatus> costumeLevelBonusStatusList)
        {
            GetCostumeBaseStatus(costumeStatus, out var agi, out var atk, out var critAtk, out var critRatio, out var evaRatio, out var hp, out var vit);
            
            var statusValue = new StatusValue(agi, atk, critAtk, critRatio, evaRatio, hp, vit);
            statusValue += GetAbilityStatusDiff(agi, atk, critAtk, critRatio, evaRatio, hp, vit, AttributeType.UNKNOWN, AbilityBehaviourStatusOrganizationConditionType.COSTUME, abilityStatusList);

            if (partsMainStatusList != null && partsSubStatusList != null)
                statusValue += GetPartsStatusDiff(agi, atk, critAtk, critRatio, evaRatio, hp, vit, partsMainStatusList, partsSubStatusList);

            if (characterBoardStatusList != null)
                statusValue += GetCharacterBoardStatusDiff(agi, atk, critAtk, critRatio, evaRatio, hp, vit, characterBoardStatusList);

            if (costumeLevelBonusStatusList != null)
                statusValue += GetCostumeLevelBonusStatusDiff(agi, atk, critAtk, critRatio, evaRatio, hp, vit, costumeLevelBonusStatusList);

            return statusValue;
        }

        public static StatusValue GetWeaponStatus(DataWeaponStatus weaponStatus, List<DataAbilityStatus> abilityStatusList, bool isSkillful, bool isMainWeapon)
        {
            if (weaponStatus == null)
                return new StatusValue();

            GetWeaponBaseStatus(weaponStatus, out var atk, out var hp, out var vit);

            // Summary: If weapon is not skillful, half value. If not main weapon, half value again

            // ---
            var localVit = vit;
            if (vit < 0)
                localVit++;
            if (!isSkillful)
                vit = localVit >> 1;

            var localHp = hp;
            if (hp < 0)
                localHp++;
            if (!isSkillful)
                hp = localHp >> 1;

            var localAtk = atk;
            if (atk < 0)
                localAtk++;
            if (!isSkillful)
                atk = localAtk >> 1;

            // ---
            localAtk = atk;
            if (atk < 0)
                localAtk = atk + 1;

            localHp = hp;
            if (hp < 0)
                localHp = hp + 1;

            localVit = vit;
            if (vit < 0)
                localVit = vit + 1;

            // ---
            if (!isMainWeapon)
            {
                hp = localHp >> 1;
                vit = localVit >> 1;
                atk = localAtk >> 1;
            }

            var baseStatus = new StatusValue(0, atk, 0, 0, 0, hp, vit);
            return baseStatus + GetAbilityStatusDiff(0, atk, 0, 0, 0, hp, vit, weaponStatus.AttributeType, AbilityBehaviourStatusOrganizationConditionType.WEAPON, abilityStatusList);
        }

        public static StatusValue GetWeaponStatus(DataWeaponStatus weaponStatus, List<DataAbilityStatus> abilityStatusList)
        {
            if (weaponStatus == null)
                return new StatusValue();

            GetWeaponBaseStatus(weaponStatus, out var atk, out var hp, out var vit);

            var baseStatus = new StatusValue(0, atk, 0, 0, 0, hp, vit);
            return baseStatus + GetAbilityStatusDiff(0, atk, 0, 0, 0, hp, vit, weaponStatus.AttributeType, AbilityBehaviourStatusOrganizationConditionType.WEAPON, abilityStatusList);
        }

        public static StatusValue GetCompanionStatus(DataCompanionStatus companionStatus, List<DataAbilityStatus> abilityStatusList)
        {
            GetCompanionBaseStatus(companionStatus, out var atk, out var hp, out var vit);

            var baseStatus = new StatusValue(0, atk, 0, 0, 0, hp, vit);
            return baseStatus + GetAbilityStatusDiff(0, atk, 0, 0, 0, hp, vit, companionStatus.AttributeType, AbilityBehaviourStatusOrganizationConditionType.COMPANION, abilityStatusList);
        }

        public static StatusValue GetPartsStatusDiff(int agility, int attack, int criticalAttack, int criticalRatio, int evasionRatio, int hp, int vitality, List<DataPartsMainStatus> partsMainStatusList, List<DataPartsSubStatus> partsSubStatusList)
        {
            var addAgi = 0;
            var addAtk = 0;
            var addCritAtk = 0;
            var addCritRate = 0;
            var addEvaRate = 0;
            var addHp = 0;
            var addVit = 0;

            var multAgi = 0;
            var multAtk = 0;
            var multCritAtk = 0;
            var multCritRate = 0;
            var multEvaRate = 0;
            var multHp = 0;
            var multVit = 0;

            foreach (var mainPart in partsMainStatusList)
            {
                var setting = mainPart.NumericalFunctionSetting;
                var mainDiff = PartsServal.calcStatusDiffByMainOption(mainPart.Level, setting.BaseValue, setting.NumericalFunctionType, setting.FunctionParameters);

                switch (mainPart.StatusKindType)
                {
                    case StatusKindType.AGILITY:
                        if (mainPart.StatusCalculationType == StatusCalculationType.ADD)
                            addAgi += mainDiff;
                        if (mainPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multAgi += mainDiff;
                        break;

                    case StatusKindType.ATTACK:
                        if (mainPart.StatusCalculationType == StatusCalculationType.ADD)
                            addAtk += mainDiff;
                        if (mainPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multAtk += mainDiff;
                        break;

                    case StatusKindType.CRITICAL_ATTACK:
                        if (mainPart.StatusCalculationType == StatusCalculationType.ADD)
                            addCritAtk += mainDiff;
                        if (mainPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multCritAtk += mainDiff;
                        break;

                    case StatusKindType.CRITICAL_RATIO:
                        if (mainPart.StatusCalculationType == StatusCalculationType.ADD)
                            addCritRate += mainDiff;
                        if (mainPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multCritRate += mainDiff;
                        break;

                    case StatusKindType.EVASION_RATIO:
                        if (mainPart.StatusCalculationType == StatusCalculationType.ADD)
                            addEvaRate += mainDiff;
                        if (mainPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multEvaRate += mainDiff;
                        break;

                    case StatusKindType.HP:
                        if (mainPart.StatusCalculationType == StatusCalculationType.ADD)
                            addHp += mainDiff;
                        if (mainPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multHp += mainDiff;
                        break;

                    case StatusKindType.VITALITY:
                        if (mainPart.StatusCalculationType == StatusCalculationType.ADD)
                            addVit += mainDiff;
                        if (mainPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multVit += mainDiff;
                        break;
                }
            }

            foreach (var subPart in partsSubStatusList)
            {
                switch (subPart.StatusKindType)
                {
                    case StatusKindType.AGILITY:
                        if (subPart.StatusCalculationType == StatusCalculationType.ADD)
                            addAgi += subPart.StatusChangeValue;
                        if (subPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multAgi += subPart.StatusChangeValue;
                        break;

                    case StatusKindType.ATTACK:
                        if (subPart.StatusCalculationType == StatusCalculationType.ADD)
                            addAtk += subPart.StatusChangeValue;
                        if (subPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multAtk += subPart.StatusChangeValue;
                        break;

                    case StatusKindType.CRITICAL_ATTACK:
                        if (subPart.StatusCalculationType == StatusCalculationType.ADD)
                            addCritAtk += subPart.StatusChangeValue;
                        if (subPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multCritAtk += subPart.StatusChangeValue;
                        break;

                    case StatusKindType.CRITICAL_RATIO:
                        if (subPart.StatusCalculationType == StatusCalculationType.ADD)
                            addCritRate += subPart.StatusChangeValue;
                        if (subPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multCritRate += subPart.StatusChangeValue;
                        break;

                    case StatusKindType.EVASION_RATIO:
                        if (subPart.StatusCalculationType == StatusCalculationType.ADD)
                            addEvaRate += subPart.StatusChangeValue;
                        if (subPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multEvaRate += subPart.StatusChangeValue;
                        break;

                    case StatusKindType.HP:
                        if (subPart.StatusCalculationType == StatusCalculationType.ADD)
                            addHp += subPart.StatusChangeValue;
                        if (subPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multHp += subPart.StatusChangeValue;
                        break;

                    case StatusKindType.VITALITY:
                        if (subPart.StatusCalculationType == StatusCalculationType.ADD)
                            addVit += subPart.StatusChangeValue;
                        if (subPart.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multVit += subPart.StatusChangeValue;
                        break;
                }
            }

            var addStatus = new StatusValue(addAgi, addAtk, addCritAtk, addCritRate, addEvaRate, addHp, addVit);
            var multStatus = GetStatusDiff(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality, StatusCalculationType.MULTIPLY,
                multAgi, multAtk, multCritAtk, multCritRate, multEvaRate, multHp, multVit);

            return addStatus + multStatus;
        }

        private static StatusValue GetCharacterBoardStatusDiff(int agility, int attack, int criticalAttack, int criticalRatio, int evasionRatio, int hp, int vitality, List<DataCharacterBoardStatus> characterBoardStatusList)
        {
            var addAgi = 0;
            var addAtk = 0;
            var addCritAtk = 0;
            var addCritRate = 0;
            var addEvaRate = 0;
            var addHp = 0;
            var addVit = 0;

            var multAgi = 0;
            var multAtk = 0;
            var multCritAtk = 0;
            var multCritRate = 0;
            var multEvaRate = 0;
            var multHp = 0;
            var multVit = 0;

            foreach (var status in characterBoardStatusList)
            {
                if (status.StatusCalculationType == StatusCalculationType.MULTIPLY)
                {
                    multAgi += status.StatusChangeValue.Agility;
                    multAtk += status.StatusChangeValue.Attack;
                    multCritAtk += status.StatusChangeValue.CriticalAttack;
                    multCritRate += status.StatusChangeValue.CriticalRatio;
                    multEvaRate += status.StatusChangeValue.EvasionRatio;
                    multHp += status.StatusChangeValue.Hp;
                    multVit += status.StatusChangeValue.Vitality;
                }
                else if (status.StatusCalculationType == StatusCalculationType.ADD)
                {
                    addAgi += status.StatusChangeValue.Agility;
                    addAtk += status.StatusChangeValue.Attack;
                    addCritAtk += status.StatusChangeValue.CriticalAttack;
                    addCritRate += status.StatusChangeValue.CriticalRatio;
                    addEvaRate += status.StatusChangeValue.EvasionRatio;
                    addHp += status.StatusChangeValue.Hp;
                    addVit += status.StatusChangeValue.Vitality;
                }
            }

            var addStatus = new StatusValue(addAgi, addAtk, addCritAtk, addCritRate, addEvaRate, addHp, addVit);
            var multStatus = GetStatusDiff(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality, StatusCalculationType.MULTIPLY,
                multAgi, multAtk, multCritAtk, multCritRate, multEvaRate, multHp, multVit);

            return addStatus + multStatus;
        }

        private static StatusValue GetCostumeLevelBonusStatusDiff(int agility, int attack, int criticalAttack, int criticalRatio, int evasionRatio, int hp, int vitality, List<DataCostumeLevelBonusStatus> costumeLevelBonusStatusList)
        {
            var addAgi = 0;
            var addAtk = 0;
            var addCritAtk = 0;
            var addCritRate = 0;
            var addEvaRate = 0;
            var addHp = 0;
            var addVit = 0;

            var multAgi = 0;
            var multAtk = 0;
            var multCritAtk = 0;
            var multCritRate = 0;
            var multEvaRate = 0;
            var multHp = 0;
            var multVit = 0;

            foreach (var bonus in costumeLevelBonusStatusList)
            {
                if (bonus.StatusCalculationType == StatusCalculationType.MULTIPLY)
                {
                    multAgi += bonus.StatusChangeValue.Agility;
                    multAtk += bonus.StatusChangeValue.Attack;
                    multCritAtk += bonus.StatusChangeValue.CriticalAttack;
                    multCritRate += bonus.StatusChangeValue.CriticalRatio;
                    multEvaRate += bonus.StatusChangeValue.EvasionRatio;
                    multHp += bonus.StatusChangeValue.Hp;
                    multVit += bonus.StatusChangeValue.Vitality;
                }
                else if (bonus.StatusCalculationType == StatusCalculationType.ADD)
                {
                    addAgi += bonus.StatusChangeValue.Agility;
                    addAtk += bonus.StatusChangeValue.Attack;
                    addCritAtk += bonus.StatusChangeValue.CriticalAttack;
                    addCritRate += bonus.StatusChangeValue.CriticalRatio;
                    addEvaRate += bonus.StatusChangeValue.EvasionRatio;
                    addHp += bonus.StatusChangeValue.Hp;
                    addVit += bonus.StatusChangeValue.Vitality;
                }
            }

            var addStatus = new StatusValue(addAgi, addAtk, addCritAtk, addCritRate, addEvaRate, addHp, addVit);
            var multStatus = GetStatusDiff(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality, StatusCalculationType.MULTIPLY,
                multAgi, multAtk, multCritAtk, multCritRate, multEvaRate, multHp, multVit);

            return addStatus + multStatus;
        }

        private static StatusValue GetAbilityStatusDiff(int agility, int attack, int criticalAttack, int criticalRatio, int evasionRatio, int hp, int vitality, AttributeType attributeType, AbilityBehaviourStatusOrganizationConditionType organizationConditionType, List<DataAbilityStatus> abilityStatusList)
        {
            var addAgi = 0;
            var addAtk = 0;
            var addCritAtk = 0;
            var addCritRate = 0;
            var addEvaRate = 0;
            var addHp = 0;
            var addVit = 0;

            var multAgi = 0;
            var multAtk = 0;
            var multCritAtk = 0;
            var multCritRate = 0;
            var multEvaRate = 0;
            var multHp = 0;
            var multVit = 0;

            foreach (var ability in abilityStatusList)
            {
                var isOrg = (ability.OrganizationConditionType == AbilityBehaviourStatusOrganizationConditionType.ALL &&
                             (organizationConditionType == AbilityBehaviourStatusOrganizationConditionType.COSTUME || ability.AbilityBehaviourStatusChangeType != AbilityBehaviourStatusChangeType.ADD)) ||
                            ability.OrganizationConditionType == organizationConditionType;
                if (!isOrg)
                    continue;

                var attributeCheck = AbilityAttributeConditionTypeCheck(attributeType, ability.AttributeConditionType);
                if (!attributeCheck)
                    continue;

                if (ability.AbilityBehaviourStatusChangeType == AbilityBehaviourStatusChangeType.MULTIPLY)
                {
                    multAgi += ability.StatusChangeValue.Agility;
                    multAtk += ability.StatusChangeValue.Attack;
                    multCritAtk += ability.StatusChangeValue.CriticalAttack;
                    multCritRate += ability.StatusChangeValue.CriticalRatio;
                    multEvaRate += ability.StatusChangeValue.EvasionRatio;
                    multHp += ability.StatusChangeValue.Hp;
                    multVit += ability.StatusChangeValue.Vitality;
                }
                else if (ability.AbilityBehaviourStatusChangeType == AbilityBehaviourStatusChangeType.ADD)
                {
                    addAgi += ability.StatusChangeValue.Agility;
                    addAtk += ability.StatusChangeValue.Attack;
                    addCritAtk += ability.StatusChangeValue.CriticalAttack;
                    addCritRate += ability.StatusChangeValue.CriticalRatio;
                    addEvaRate += ability.StatusChangeValue.EvasionRatio;
                    addHp += ability.StatusChangeValue.Hp;
                    addVit += ability.StatusChangeValue.Vitality;
                }
            }

            var addStatus = new StatusValue(addAgi, addAtk, addCritAtk, addCritRate, addEvaRate, addHp, addVit);
            var multStatus = GetStatusDiff(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality, StatusCalculationType.MULTIPLY,
                multAgi, multAtk, multCritAtk, multCritRate, multEvaRate, multHp, multVit);

            return addStatus + multStatus;
        }

        private static StatusValue GetStatusDiff(int agility, int attack, int criticalAttack, int criticalRatio, int evasionRatio, int hp, int vitality, StatusCalculationType statusCalculationType, int agilityChangeValue, int attackChangeValue, int criticalAttackChangeValue, int criticalRatioChangeValue, int evasionRatioChangeValue, int hpChangeValue, int vitalityChangeValue)
        {
            if (statusCalculationType == StatusCalculationType.ADD)
                return new StatusValue(
                    agilityChangeValue,
                    attackChangeValue,
                    criticalAttackChangeValue,
                    criticalRatioChangeValue,
                    evasionRatioChangeValue,
                    hpChangeValue,
                    vitalityChangeValue);

            return new StatusValue(
                PermilServal.multiplyPermil(agility, agilityChangeValue),
                PermilServal.multiplyPermil(attack, attackChangeValue),
                PermilServal.multiplyPermil(criticalAttack, criticalAttackChangeValue),
                PermilServal.multiplyPermil(criticalRatio, criticalRatioChangeValue),
                PermilServal.multiplyPermil(evasionRatio, evasionRatioChangeValue),
                PermilServal.multiplyPermil(hp, hpChangeValue),
                PermilServal.multiplyPermil(vitality, vitalityChangeValue));
        }

        public static void GetCostumeBaseStatus(DataCostumeStatus costumeStatus, out int agility, out int attack, out int criticalAttack, out int criticalRatio, out int evasionRatio, out int hp, out int vitality)
        {
            var settings = costumeStatus.StatusCalculationSettings;
            var level = costumeStatus.Level;

            agility = CalcCostumeStatus(settings, level, StatusKindType.AGILITY);
            attack = CalcCostumeStatus(settings, level, StatusKindType.ATTACK);
            criticalAttack = CalcCostumeStatus(settings, level, StatusKindType.CRITICAL_ATTACK);
            criticalRatio = CalcCostumeStatus(settings, level, StatusKindType.CRITICAL_RATIO);
            evasionRatio = CalcCostumeStatus(settings, level, StatusKindType.EVASION_RATIO);
            hp = CalcCostumeStatus(settings, level, StatusKindType.HP);
            vitality = CalcCostumeStatus(settings, level, StatusKindType.VITALITY);
        }

        public static void GetWeaponBaseStatus(DataWeaponStatus weaponStatus, out int attack, out int hp, out int vitality)
        {
            attack = 0;
            hp = 0;
            vitality = 0;

            if (weaponStatus == null)
                return;

            attack = CalcWeaponStatus(weaponStatus.StatusCalculationSettings, weaponStatus.Level, StatusKindType.ATTACK);
            hp = CalcWeaponStatus(weaponStatus.StatusCalculationSettings, weaponStatus.Level, StatusKindType.HP);
            vitality = CalcWeaponStatus(weaponStatus.StatusCalculationSettings, weaponStatus.Level, StatusKindType.VITALITY);
        }

        public static void GetCompanionBaseStatus(DataCompanionStatus companionStatus, out int attack, out int hp, out int vitality)
        {
            attack = CalcCompanionStatus(companionStatus.StatusCalculationSettings, companionStatus.Level, StatusKindType.ATTACK);
            hp = CalcCompanionStatus(companionStatus.StatusCalculationSettings, companionStatus.Level, StatusKindType.HP);
            vitality = CalcCompanionStatus(companionStatus.StatusCalculationSettings, companionStatus.Level, StatusKindType.VITALITY);
        }

        private static int CalcCostumeStatus(Dictionary<StatusKindType, NumericalFunctionSetting> calculationSettings, int level, StatusKindType statusKindType)
        {
            if (!calculationSettings.TryGetValue(statusKindType, out var setting))
                return 0;

            return CostumeServal.calcStatusValue(setting.BaseValue, level, setting.NumericalFunctionType, setting.FunctionParameters);
        }

        private static int CalcWeaponStatus(Dictionary<StatusKindType, NumericalFunctionSetting> calculationSettings, int level, StatusKindType statusKindType)
        {
            if (!calculationSettings.TryGetValue(statusKindType, out var setting))
                return 0;

            return WeaponServal.calcStatusValue(setting.BaseValue, level, setting.NumericalFunctionType, setting.FunctionParameters);
        }

        private static int CalcCompanionStatus(Dictionary<StatusKindType, NumericalFunctionSetting> calculationSettings, int level, StatusKindType statusKindType)
        {
            if (!calculationSettings.TryGetValue(statusKindType, out var setting))
                return 0;

            return CompanionServal.calcStatusValue(setting.BaseValue, level, setting.NumericalFunctionType, setting.FunctionParameters);
        }

        private static bool AbilityAttributeConditionTypeCheck(AttributeType attributeType, AttributeConditionType conditionType)
        {
            if (conditionType == AttributeConditionType.ALL)
                return true;

            switch (attributeType)
            {
                case AttributeType.DARK:
                    return conditionType == AttributeConditionType.DARK;

                case AttributeType.FIRE:
                    return conditionType == AttributeConditionType.FIRE;

                case AttributeType.LIGHT:
                    return conditionType == AttributeConditionType.LIGHT;

                case AttributeType.NOTHING:
                    return conditionType == AttributeConditionType.NOTHING;

                case AttributeType.WATER:
                    return conditionType == AttributeConditionType.WATER;

                case AttributeType.WIND:
                    return conditionType == AttributeConditionType.WIND;
            }

            return false;
        }
    }
}
