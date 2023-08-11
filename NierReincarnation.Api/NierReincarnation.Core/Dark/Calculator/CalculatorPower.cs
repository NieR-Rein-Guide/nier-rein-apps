using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Subsystem.Serval;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.Core.Dark.Calculator;

public static class CalculatorPower
{
    public static int CalculateDeckPower(long userId, DataDeck dataDeck)
    {
        CalculatorStatusOutgame.ApplyDeckAbilityStatusList(userId, dataDeck);
        var result = 0;

        foreach (var actor in dataDeck.UserDeckActors)
        {
            result += CalculateDeckActorPower(userId, actor, dataDeck);
        }

        return result;
    }

    public static int CalculateIndividualCostumePower(DataOutgameCostume costume, StatusValue costumeStatus)
    {
        var resultPower = CalculateCostumeStatusPower(costumeStatus.Hp, costumeStatus.Attack, costumeStatus.Vitality, out var hpPower, out var atkPower, out var vitPower);

        resultPower += CalculateIndividualSkillPower(costume.CostumeActiveSkill, AttributeType.UNKNOWN, hpPower, atkPower, vitPower);

        foreach (var ability in costume.CostumeAbilities)
        {
            resultPower += CalculateIndividualAbilityPower(ability, AttributeType.UNKNOWN, hpPower, atkPower, vitPower);
        }

        return resultPower;
    }

    public static int CalculateIndividualWeaponPower(DataWeapon weapon, StatusValue weaponStatus)
    {
        var result = CalculateWeaponStatusPower(weaponStatus.Hp, weaponStatus.Attack, weaponStatus.Vitality, false, false, out var hpPower, out var atkPower, out var vitPower);

        foreach (var skill in weapon.Skills)
        {
            result += CalculateIndividualSkillPower(skill, weapon.WeaponStatus.AttributeType, hpPower, atkPower, vitPower);
        }

        foreach (var ability in weapon.Abilities)
        {
            result += CalculateIndividualAbilityPower(ability, AttributeType.UNKNOWN, hpPower, atkPower, vitPower);
        }

        return result;
    }

    public static int CalculateIndividualCompanionPower(DataOutgameCompanion companion, StatusValue companionStatus)
    {
        var power = CalculateCompanionStatusPower(companionStatus.Hp, companionStatus.Attack, companionStatus.Vitality, out var hpPower, out var atkPower, out var vitPower);

        var skillPower = CalculateIndividualSkillPower(companion.CompanionSkill, companion.CompanionStatus.AttributeType, hpPower, atkPower, vitPower);
        var abilityPower = CalculateIndividualAbilityPower(companion.CompanionAbility, companion.CompanionStatus.AttributeType, hpPower, atkPower, vitPower);

        return power + skillPower + abilityPower;
    }

    public static int CalculateIndividualPartsPower(DataOutgameMemory parts)
    {
        var mainStatus = parts.MainMemoryStatus;
        var settings = mainStatus.NumericalFunctionSetting;

        var baseValue = settings.BaseValue;
        var functionType = settings.NumericalFunctionType;
        var level = mainStatus.Level;

        var mainOption = PartsServal.calcStatusDiffByMainOption(level, baseValue, functionType, settings.FunctionParameters);

        var agi = mainOption;
        if (mainStatus.StatusKindType != StatusKindType.AGILITY)
            agi = 0;

        var atk = mainOption;
        if (mainStatus.StatusKindType != StatusKindType.ATTACK)
            atk = 0;

        var critAtk = mainOption;
        if (mainStatus.StatusKindType != StatusKindType.CRITICAL_ATTACK)
            critAtk = 0;

        var critRate = mainOption;
        if (mainStatus.StatusKindType != StatusKindType.CRITICAL_RATIO)
            critRate = 0;

        var evaRate = mainOption;
        if (mainStatus.StatusKindType != StatusKindType.EVASION_RATIO)
            evaRate = 0;

        var hp = mainOption;
        if (mainStatus.StatusKindType != StatusKindType.HP)
            hp = 0;

        var vit = mainOption;
        if (mainStatus.StatusKindType != StatusKindType.VITALITY)
            vit = 0;

        var statusPower = CalculatePartsStatusPower(agi, atk, critAtk, critRate, evaRate, hp, vit, mainStatus.StatusCalculationType);

        foreach (var subStatus in parts.SubMemoryStatus)
        {
            switch (subStatus.StatusKindType)
            {
                case StatusKindType.AGILITY:
                    hp = 0;
                    evaRate = 0;
                    critRate = 0;
                    critAtk = 0;
                    atk = 0;
                    agi = subStatus.StatusChangeValue;
                    break;

                case StatusKindType.ATTACK:
                    hp = 0;
                    evaRate = 0;
                    critRate = 0;
                    critAtk = 0;
                    atk = subStatus.StatusChangeValue;
                    agi = 0;
                    break;

                case StatusKindType.CRITICAL_ATTACK:
                    hp = 0;
                    evaRate = 0;
                    critRate = 0;
                    critAtk = subStatus.StatusChangeValue;
                    atk = 0;
                    agi = 0;
                    break;

                case StatusKindType.CRITICAL_RATIO:
                    hp = 0;
                    evaRate = 0;
                    critRate = subStatus.StatusChangeValue;
                    critAtk = 0;
                    atk = 0;
                    agi = 0;
                    break;

                case StatusKindType.EVASION_RATIO:
                    hp = 0;
                    evaRate = subStatus.StatusChangeValue;
                    critRate = 0;
                    critAtk = 0;
                    atk = 0;
                    agi = 0;
                    break;

                case StatusKindType.HP:
                    hp = subStatus.StatusChangeValue;
                    evaRate = 0;
                    critRate = 0;
                    critAtk = 0;
                    atk = 0;
                    agi = 0;
                    break;
            }

            statusPower += CalculatePartsStatusPower(agi, atk, critAtk, critRate, evaRate, hp, vit, subStatus.StatusCalculationType);
        }

        return statusPower;
    }

    private static int CalculateIndividualAbilityPower(DataAbility ability, AttributeType attributeType, int hpPower, int attackPower, int vitalityPower)
    {
        if (ability.IsLocked)
        {
            return 0;
        }

        var result = 0;
        foreach (var passiveSkill in ability.PassiveSkillList)
        {
            result += CalculateIndividualSkillPower(passiveSkill, attributeType, hpPower, attackPower, vitalityPower);
        }

        return result;
    }

    private static int CalculateIndividualSkillPower(DataSkill dataSkill, AttributeType attributeType, int hpPower, int attackPower, int vitalityPower)
    {
        if (dataSkill?.IsLocked != false || dataSkill.DataSkillPower == null || dataSkill.DataSkillPower.ReferenceStatusType == PowerCalculationReferenceStatusType.NONE)
        {
            return 0;
        }

        var statusReference = 0;
        foreach (var setting in dataSkill.DataSkillPower.ReferenceStatusSettings)
        {
            var isMatch = IsMatchAttributeCondition(attributeType, setting.AttributeConditionType);
            if (!isMatch) continue;

            var settingKind = setting.ReferenceStatusKindType;
            var power = settingKind switch
            {
                StatusKindType.HP => hpPower,
                StatusKindType.VITALITY => vitalityPower,
                _ => attackPower,
            };
            statusReference += PowerServal.calcStatusReferenceValue(power, setting.CoefficientValuePermil);
        }

        return PowerServal.calcSkillPower(dataSkill.DataSkillPower.SkillPowerBaseValue, statusReference);
    }

    private static void ResetDeckActorPower(DataDeckActor deckActor)
    {
        if (deckActor == null) return;

        deckActor.AttackPower = 0;
        deckActor.HpPower = 0;
        deckActor.VitalityPower = 0;
        deckActor.Power = 0;
    }

    public static int CalculateDeckActorPower(long userId, DataDeckActor deckActor, DataDeck dataDeck)
    {
        if (deckActor == null)
            return 0;

        ResetDeckActorPower(deckActor);

        foreach (var actor in dataDeck.UserDeckActors)
        {
            if (actor == null) continue;

            if (actor.HpPower >= 1 && actor.AttackPower >= 1 && actor.VitalityPower >= 1) continue;

            CalculateDeckActorBasePower(userId, actor, out var hp, out var atk, out var vit);

            actor.HpPower = hp;
            actor.AttackPower = atk;
            actor.VitalityPower = vit;
        }

        var skillPower = CalculateSkillPower(userId, deckActor, dataDeck);
        deckActor.Power = skillPower + deckActor.HpPower + deckActor.AttackPower + deckActor.VitalityPower;

        return deckActor.Power;
    }

    private static void CalculateDeckActorBasePower(long userId, DataDeckActor deckActor, out int hpPower, out int attackPower, out int vitalityPower)
    {
        hpPower = 0;
        attackPower = 0;
        vitalityPower = 0;

        if (deckActor?.Costume == null)
            return;

        CalculateDeckCostumeStatusPower(userId, deckActor, out var hp, out var atk, out var vit);
        hpPower += hp;
        attackPower += atk;
        vitalityPower += vit;

        if (deckActor.MainWeapon != null)
        {
            CalculateDeckWeaponStatusPower(userId, deckActor.MainWeapon, deckActor, true, out hp, out atk, out vit);
            hpPower += hp;
            attackPower += atk;
            vitalityPower += vit;
        }

        if (deckActor.SubWeapon01 != null)
        {
            CalculateDeckWeaponStatusPower(userId, deckActor.SubWeapon01, deckActor, false, out hp, out atk, out vit);
            hpPower += hp;
            attackPower += atk;
            vitalityPower += vit;
        }

        if (deckActor.SubWeapon02 != null)
        {
            CalculateDeckWeaponStatusPower(userId, deckActor.SubWeapon02, deckActor, false, out hp, out atk, out vit);
            hpPower += hp;
            attackPower += atk;
            vitalityPower += vit;
        }

        if (deckActor.Companion != null)
        {
            CalculateDeckCompanionStatusPower(userId, deckActor, out hp, out atk, out vit);
            hpPower += hp;
            attackPower += atk;
            vitalityPower += vit;
        }

        if (deckActor.Memories != null && deckActor.Memories.Length != 0)
        {
            CalculateDeckPartsStatusPower(deckActor.Memories, out hp, out atk, out vit);
            hpPower += hp;
            attackPower += atk;
            vitalityPower += vit;
        }
    }

    private static int CalculateDeckCostumeStatusPower(long userId, DataDeckActor deckActor, out int hpPower, out int attackPower, out int vitalityPower)
    {
        var statusValue = CalculatorStatusOutgame.GetDeckActorCostumeStatus(userId, deckActor);
        return CalculateCostumeStatusPower(statusValue.Hp, statusValue.Attack, statusValue.Vitality, out hpPower, out attackPower, out vitalityPower);
    }

    private static int CalculateDeckWeaponStatusPower(long userId, DataWeapon dataWeapon, DataDeckActor ownerDeckActor, bool isMainWeapon, out int weaponHpPower, out int weaponAttackPower, out int weaponVitalityPower)
    {
        var weaponStatus = dataWeapon.WeaponStatus;
        var costumeStatus = ownerDeckActor.Costume.CostumeStatus;

        var actorWeaponStatus = CalculatorStatusOutgame.GetDeckActorWeaponStatus(userId, ownerDeckActor, dataWeapon, isMainWeapon, weaponStatus.WeaponType == costumeStatus.SkillfulWeaponType);
        return CalculateWeaponStatusPower(actorWeaponStatus.Hp, actorWeaponStatus.Attack, actorWeaponStatus.Vitality, false, false, out weaponHpPower, out weaponAttackPower, out weaponVitalityPower);
    }

    private static int CalculateDeckCompanionStatusPower(long userId, DataDeckActor deckActor, out int hpPower, out int attackPower, out int vitalityPower)
    {
        var companionStatus = CalculatorStatusOutgame.GetDeckActorCompanionStatus(userId, deckActor);
        return CalculateCompanionStatusPower(companionStatus.Hp, companionStatus.Attack, companionStatus.Vitality, out hpPower, out attackPower, out vitalityPower);
    }

    private static int CalculatePartsPower(DataOutgameMemory parts)
    {
        // Implemented as part of CalculateDeckPartsStatusPower
        throw new NotImplementedException();
    }

    private static void CalculateDeckPartsStatusPower(DataOutgameMemory[] partsList, out int hpPower, out int attackPower, out int vitalityPower)
    {
        hpPower = 0;
        attackPower = 0;
        vitalityPower = 0;

        if (partsList.Length == 0) return;

        var multHp = 0;
        var addHp = 0;
        var multAtk = 0;
        var addAtk = 0;
        var multVit = 0;
        var addVit = 0;

        foreach (var part in partsList)
        {
            if (part == null) continue;

            var mainStatus = part.MainMemoryStatus;
            var mainStatusSetting = mainStatus.NumericalFunctionSetting;

            var mainLvl = mainStatus.Level;
            var mainStatusBaseValue = mainStatusSetting.BaseValue;
            var mainStatusFunctionType = mainStatusSetting.NumericalFunctionType;
            var mainStatusParameters = mainStatusSetting.FunctionParameters;

            var statusValue = PartsServal.calcStatusDiffByMainOption(mainLvl, mainStatusBaseValue, mainStatusFunctionType, mainStatusParameters);

            var agi = statusValue;
            if (mainStatus.StatusKindType != StatusKindType.AGILITY)
                agi = 0;

            var atk = statusValue;
            if (mainStatus.StatusKindType != StatusKindType.ATTACK)
                atk = 0;

            var critAtk = statusValue;
            if (mainStatus.StatusKindType != StatusKindType.CRITICAL_ATTACK)
                critAtk = 0;

            var critRate = statusValue;
            if (mainStatus.StatusKindType != StatusKindType.CRITICAL_RATIO)
                critRate = 0;

            var evaRate = statusValue;
            if (mainStatus.StatusKindType != StatusKindType.EVASION_RATIO)
                evaRate = 0;

            var hp = statusValue;
            if (mainStatus.StatusKindType != StatusKindType.HP)
                hp = 0;

            var vit = statusValue;
            if (mainStatus.StatusKindType != StatusKindType.VITALITY)
                vit = 0;

            var statusPower = CalculatePartsStatusPower(agi, atk, critAtk, critRate, evaRate, hp, vit, mainStatus.StatusCalculationType);

            if ((int)mainStatus.StatusKindType <= 5)
            {
                if (mainStatus.StatusCalculationType == StatusCalculationType.MULTIPLY)
                    multAtk += statusPower;
                else if (mainStatus.StatusCalculationType == StatusCalculationType.ADD)
                    addAtk += statusPower;
            }
            else
            {
                if (mainStatus.StatusKindType == StatusKindType.VITALITY)
                {
                    if (mainStatus.StatusCalculationType == StatusCalculationType.MULTIPLY)
                        multVit += statusPower;
                    else if (mainStatus.StatusCalculationType == StatusCalculationType.ADD)
                        addVit += statusPower;
                }
                else if (mainStatus.StatusKindType == StatusKindType.HP)
                {
                    if (mainStatus.StatusCalculationType == StatusCalculationType.MULTIPLY)
                        multHp += statusPower;
                    else if (mainStatus.StatusCalculationType == StatusCalculationType.ADD)
                        addHp += statusPower;
                }
            }

            foreach (var subStatus in part.SubMemoryStatus)
            {
                switch (subStatus.StatusKindType)
                {
                    case StatusKindType.AGILITY:
                        hp = 0;
                        evaRate = 0;
                        critRate = 0;
                        critAtk = 0;
                        atk = 0;
                        agi = subStatus.StatusChangeValue;
                        break;

                    case StatusKindType.ATTACK:
                        hp = 0;
                        evaRate = 0;
                        critRate = 0;
                        critAtk = 0;
                        atk = subStatus.StatusChangeValue;
                        agi = 0;
                        break;

                    case StatusKindType.CRITICAL_ATTACK:
                        hp = 0;
                        evaRate = 0;
                        critRate = 0;
                        critAtk = subStatus.StatusChangeValue;
                        atk = 0;
                        agi = 0;
                        break;

                    case StatusKindType.CRITICAL_RATIO:
                        hp = 0;
                        evaRate = 0;
                        critRate = subStatus.StatusChangeValue;
                        critAtk = 0;
                        atk = 0;
                        agi = 0;
                        break;

                    case StatusKindType.EVASION_RATIO:
                        hp = 0;
                        evaRate = subStatus.StatusChangeValue;
                        critRate = 0;
                        critAtk = 0;
                        atk = 0;
                        agi = 0;
                        break;

                    case StatusKindType.HP:
                        hp = subStatus.StatusChangeValue;
                        evaRate = 0;
                        critRate = 0;
                        critAtk = 0;
                        atk = 0;
                        agi = 0;
                        break;
                }

                if (subStatus.StatusKindType != StatusKindType.VITALITY)
                {
                    var subStatusPower = CalculatePartsStatusPower(agi, atk, critAtk, critRate, evaRate, hp, 0, subStatus.StatusCalculationType);

                    if ((int)mainStatus.StatusKindType <= 5)
                    {
                        if (mainStatus.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            multAtk += subStatusPower;
                        else if (mainStatus.StatusCalculationType == StatusCalculationType.ADD)
                            addAtk += subStatusPower;
                    }
                    else
                    {
                        if (mainStatus.StatusKindType == StatusKindType.HP)
                        {
                            if (mainStatus.StatusCalculationType == StatusCalculationType.MULTIPLY)
                                multHp += subStatusPower;
                            else if (mainStatus.StatusCalculationType == StatusCalculationType.ADD)
                                addHp += subStatusPower;
                        }
                    }
                }
                else
                {
                    var subStatusPower = CalculatePartsStatusPower(0, 0, 0, 0, 0, 0, subStatus.StatusChangeValue, subStatus.StatusCalculationType);

                    if (mainStatus.StatusCalculationType == StatusCalculationType.ADD)
                        addVit += subStatusPower;
                    else if (mainStatus.StatusCalculationType == StatusCalculationType.MULTIPLY)
                        multVit += subStatusPower;
                }
            }
        }

        hpPower = addHp + multHp;
        attackPower = addAtk + multAtk;
        vitalityPower = addVit + multVit;
    }

    private static int CalculateSkillPower(long userId, DataDeckActor dataDeckActor, DataDeck dataDeck)
    {
        if (dataDeckActor == null)
            return 0;

        var totalPower = 0;

        if (dataDeckActor.Costume?.CostumeActiveSkill != null)
        {
            totalPower += CalculateSkillPower(dataDeckActor, dataDeck, dataDeckActor.Costume.CostumeActiveSkill);
        }

        if (dataDeckActor.MainWeapon?.Skills != null)
        {
            totalPower += dataDeckActor.MainWeapon.Skills.Sum(ms => CalculateSkillPower(dataDeckActor, dataDeck, ms));
        }

        if (dataDeckActor.Companion?.CompanionSkill != null)
        {
            totalPower += CalculateSkillPower(dataDeckActor, dataDeck, dataDeckActor.Companion.CompanionSkill);
        }

        if (dataDeckActor.Costume?.CostumeAbilities != null)
        {
            totalPower += dataDeckActor.Costume.CostumeAbilities.Sum(ca => CalculateAbilityPower(dataDeckActor, dataDeck, ca));
        }

        if (dataDeckActor.MainWeapon?.Abilities != null)
        {
            totalPower += dataDeckActor.MainWeapon.Abilities.Sum(ma => CalculateAbilityPower(dataDeckActor, dataDeck, ma));
        }

        if (dataDeckActor.SubWeapon01?.Abilities != null)
        {
            totalPower += dataDeckActor.SubWeapon01.Abilities.Sum(ma => CalculateAbilityPower(dataDeckActor, dataDeck, ma));
        }

        if (dataDeckActor.SubWeapon02?.Abilities != null)
        {
            totalPower += dataDeckActor.SubWeapon02.Abilities.Sum(ma => CalculateAbilityPower(dataDeckActor, dataDeck, ma));
        }

        if (dataDeckActor.Companion?.CompanionAbility != null)
        {
            totalPower += CalculateAbilityPower(dataDeckActor, dataDeck, dataDeckActor.Companion.CompanionAbility);
        }

        if (dataDeckActor.MemorySeriesBonus != null)
        {
            totalPower += dataDeckActor.MemorySeriesBonus.Sum(sb => CalculateAbilityPower(dataDeckActor, dataDeck, sb));
        }

        if (dataDeckActor.Thought.Ability != null)
        {
            totalPower += CalculateAbilityPower(dataDeckActor, dataDeck, dataDeckActor.Thought.Ability);
        }

        if (dataDeckActor.Costume == null)
            return totalPower;

        if (OutgameAbilityCache.IsCacheEnabled && OutgameAbilityCache.TryGetCharacterAbilityPassiveSkillList(dataDeckActor.Costume.CharacterId, out var charAbilityPassiveSkills))
        {
            return totalPower + CalculateSkillsPower(dataDeckActor, dataDeck, charAbilityPassiveSkills);
        }

        var rankAbilities = CalculatorCharacterRank.CreateCharacterRankAbilityList(userId, dataDeckActor.Costume.CharacterId);
        totalPower += rankAbilities?.Sum(ra => CalculateAbilityPower(dataDeckActor, dataDeck, ra)) ?? 0;

        var boardAbilities = CalculatorCharacterBoard.CreateCharacterBoardAbilityList(userId, dataDeckActor.Costume.CharacterId);
        totalPower += boardAbilities?.Sum(ba => CalculateAbilityPower(dataDeckActor, dataDeck, ba)) ?? 0;

        return totalPower;
    }

    private static int CalculateAbilityPower(DataDeckActor ownerDeckActor, DataDeck dataDeck, DataAbility dataAbility)
    {
        if (dataAbility.IsLocked || (dataAbility.PassiveSkillList?.Count ?? 0) == 0)
            return 0;

        var result = 0;
        foreach (var passiveSkill in dataAbility.PassiveSkillList)
        {
            result += CalculateSkillPower(ownerDeckActor, dataDeck, passiveSkill);
        }

        return result;
    }

    private static int CalculateSkillsPower(DataDeckActor ownerDeckActor, DataDeck dataDeck, List<DataSkill> skills)
    {
        return skills.Count != 0 ? skills.Sum(s => CalculateSkillPower(ownerDeckActor, dataDeck, s)) : 0;
    }

    private static int CalculateSkillPower(DataDeckActor ownerDeckActor, DataDeck dataDeck, DataSkill dataSkill)
    {
        var settings = dataSkill.DataSkillPower.ReferenceStatusSettings;
        var baseValue = dataSkill.DataSkillPower.SkillPowerBaseValue;

        var statusReference = 0;
        foreach (var setting in settings)
        {
            statusReference += CalculateStatusReferenceValue(ownerDeckActor, dataSkill.DataSkillPower.ReferenceStatusType, dataDeck, setting);
        }

        return PowerServal.calcSkillPower(baseValue, statusReference);
    }

    private static int CalculateStatusReferenceValue(DataDeckActor ownerDeckActor, PowerCalculationReferenceStatusType referenceType, DataDeck dataDeck, DataPowerReferenceStatus referenceStatus)
    {
        if (referenceType == PowerCalculationReferenceStatusType.UNKNOWN || referenceType == PowerCalculationReferenceStatusType.NONE)
            return 0;

        if (dataDeck.UserDeckActors.Length == 0)
            return 0;

        var result = 0;
        foreach (var actor in dataDeck.UserDeckActors)
        {
            if (referenceType == PowerCalculationReferenceStatusType.SELF && ownerDeckActor.UserDeckActorUuid != actor.UserDeckActorUuid)
                continue;

            var mainAttribute = actor.MainWeapon?.WeaponStatus.AttributeType ?? AttributeType.UNKNOWN;

            var isCondMatched = IsMatchAttributeCondition(mainAttribute, referenceStatus.AttributeConditionType);
            if (!isCondMatched)
                continue;

            var power = 0;
            if (referenceStatus.ReferenceStatusKindType < StatusKindType.VITALITY)
                power = actor.AttackPower;
            else if (referenceStatus.ReferenceStatusKindType == StatusKindType.VITALITY)
                power = actor.VitalityPower;
            else if (referenceStatus.ReferenceStatusKindType == StatusKindType.HP)
                power = actor.HpPower;

            result += PowerServal.calcStatusReferenceValue(power, referenceStatus.CoefficientValuePermil);
        }

        return result;
    }

    private static int CalculateCostumeStatusPower(int hp, int attack, int vitality, out int hpPower, out int attackPower, out int vitalityPower)
    {
        var instance = DeckPowerCalculationConstantValues.Instance;

        hpPower = PowerServal.calcStatusPower(hp, instance.CostumePowerHpCoefficientPermil);
        attackPower = PowerServal.calcStatusPower(attack, instance.CostumePowerAttackCoefficientPermil);
        vitalityPower = PowerServal.calcStatusPower(vitality, instance.CostumePowerVitalityCoefficientPermil);

        return hpPower + attackPower + vitalityPower;
    }

    private static int CalculateWeaponStatusPower(int hp, int attack, int vitality, bool isSkillful, bool isMainWeapon, out int hpPower, out int attackPower, out int vitalityPower)
    {
        var instance = DeckPowerCalculationConstantValues.Instance;

        hpPower = PowerServal.calcWeaponStatusPower(hp, instance.WeaponPowerHpCoefficientPermil);
        attackPower = PowerServal.calcWeaponStatusPower(attack, instance.WeaponPowerAttackCoefficientPermil);
        vitalityPower = PowerServal.calcWeaponStatusPower(vitality, instance.WeaponPowerVitalityCoefficientPermil);

        return hpPower + attackPower + vitalityPower;
    }

    private static int CalculateCompanionStatusPower(int hp, int attack, int vitality, out int companionHpPower, out int companionAttackPower, out int companionVitalityPower)
    {
        var instance = DeckPowerCalculationConstantValues.Instance;

        companionHpPower = PowerServal.calcWeaponStatusPower(hp, instance.CompanionPowerHpCoefficientPermil);
        companionAttackPower = PowerServal.calcWeaponStatusPower(attack, instance.CompanionPowerAttackCoefficientPermil);
        companionVitalityPower = PowerServal.calcWeaponStatusPower(vitality, instance.CompanionPowerVitalityCoefficientPermil);

        return companionHpPower + companionAttackPower + companionVitalityPower;
    }

    private static int CalculatePartsStatusPower(int agility, int attack, int criticalAttack, int criticalRatio, int evasionRatio, int hp, int vitality, StatusCalculationType statusCalculationType)
    {
        if (statusCalculationType == StatusCalculationType.UNKNOWN)
            return 0;

        var instance = DeckPowerCalculationConstantValues.Instance;

        if (statusCalculationType == StatusCalculationType.MULTIPLY)
        {
            var agiBase = instance.PartsMulPowerAgilityBaseValue;
            var atkBase = instance.PartsMulPowerAttackBaseValue;
            var critAtkBase = instance.PartsMulPowerCriticalAttackBaseValue;
            var critRateBase = instance.PartsMulPowerCriticalRatioBaseValue;
            var evaRateBase = instance.PartsMulPowerEvasionRatioBaseValue;
            var hpBase = instance.PartsMulPowerHpBaseValue;
            var vitBase = instance.PartsMulPowerVitalityBaseValue;

            return PowerServal.calcStatusPower(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality, agiBase, atkBase, critAtkBase, critRateBase, evaRateBase, hpBase, vitBase);
        }
        else
        {
            var agiBase = instance.PartsAddPowerAgilityCoefficientPermil;
            var atkBase = instance.PartsAddPowerAttackCoefficientPermil;
            var critAtkBase = instance.PartsAddPowerCriticalAttackCoefficientPermil;
            var critRateBase = instance.PartsAddPowerCriticalRatioCoefficientPermil;
            var evaRateBase = instance.PartsAddPowerEvasionRatioCoefficientPermil;
            var hpBase = instance.PartsAddPowerHpCoefficientPermil;
            var vitBase = instance.PartsAddPowerVitalityCoefficientPermil;

            return PowerServal.calcStatusPower(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality, agiBase, atkBase, critAtkBase, critRateBase, evaRateBase, hpBase, vitBase);
        }
    }

    private static bool IsMatchAttributeCondition(AttributeType attributeType, AttributeConditionType conditionType)
    {
        return conditionType switch
        {
            AttributeConditionType.DARK => attributeType == AttributeType.DARK,
            AttributeConditionType.FIRE => attributeType == AttributeType.FIRE,
            AttributeConditionType.LIGHT => attributeType == AttributeType.LIGHT,
            AttributeConditionType.WATER => attributeType == AttributeType.WATER,
            AttributeConditionType.WIND => attributeType == AttributeType.WIND,
            AttributeConditionType.NOTHING => attributeType == AttributeType.NOTHING,
            AttributeConditionType.ALL => true,
            _ => false,
        };
    }
}
