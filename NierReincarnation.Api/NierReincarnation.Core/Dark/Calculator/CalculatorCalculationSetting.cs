using NierReincarnation.Core.Dark.Game.TurnBattle;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator;

public static class CalculatorCalculationSetting
{
    public static Dictionary<StatusKindType, NumericalFunctionSetting> CreateCostumeStatusCalculationSetting(EntityMCostume entityMBattleActorCostume, EntityMCostumeBaseStatus baseStatus)
    {
        var statusCalc = GetEntityMBattleActorCostumeStatusCalculation(entityMBattleActorCostume);

        return new Dictionary<StatusKindType, NumericalFunctionSetting>
        {
            [StatusKindType.AGILITY] = CreateStatusCalculationSetting(statusCalc.AgilityNumericalFunctionId, baseStatus.Agility),
            [StatusKindType.ATTACK] = CreateStatusCalculationSetting(statusCalc.AttackNumericalFunctionId, baseStatus.Attack),
            [StatusKindType.CRITICAL_ATTACK] = CreateStatusCalculationSetting(statusCalc.CriticalAttackRatioPermilNumericalFunctionId, baseStatus.CriticalAttackRatioPermil),
            [StatusKindType.CRITICAL_RATIO] = CreateStatusCalculationSetting(statusCalc.CriticalRatioPermilNumericalFunctionId, baseStatus.CriticalRatioPermil),
            [StatusKindType.EVASION_RATIO] = CreateStatusCalculationSetting(statusCalc.EvasionRatioPermilNumericalFunctionId, baseStatus.EvasionRatioPermil),
            [StatusKindType.HP] = CreateStatusCalculationSetting(statusCalc.HpNumericalFunctionId, baseStatus.Hp),
            [StatusKindType.VITALITY] = CreateStatusCalculationSetting(statusCalc.VitalityNumericalFunctionId, baseStatus.Vitality)
        };
    }

    public static Dictionary<StatusKindType, NumericalFunctionSetting> CreateWeaponStatusCalculationSetting(EntityMWeapon entityMWeapon, EntityMWeaponBaseStatus baseStatus)
    {
        var statusCalc = GetEntityMWeaponStatusCalculation(entityMWeapon);

        return new Dictionary<StatusKindType, NumericalFunctionSetting>
        {
            [StatusKindType.ATTACK] = CreateStatusCalculationSetting(statusCalc.AttackNumericalFunctionId, baseStatus.Attack),
            [StatusKindType.HP] = CreateStatusCalculationSetting(statusCalc.HpNumericalFunctionId, baseStatus.Hp),
            [StatusKindType.VITALITY] = CreateStatusCalculationSetting(statusCalc.VitalityNumericalFunctionId, baseStatus.Vitality)
        };
    }

    public static Dictionary<StatusKindType, NumericalFunctionSetting> CreateCompanionStatusCalculationSetting(EntityMCompanion entityMCompanion, EntityMCompanionBaseStatus baseStatus)
    {
        var statusCalc = GetEntityMCompanionStatusCalculation(entityMCompanion);

        return new Dictionary<StatusKindType, NumericalFunctionSetting>
        {
            [StatusKindType.ATTACK] = CreateStatusCalculationSetting(statusCalc.AttackNumericalFunctionId, baseStatus.Attack),
            [StatusKindType.HP] = CreateStatusCalculationSetting(statusCalc.HpNumericalFunctionId, baseStatus.Hp),
            [StatusKindType.VITALITY] = CreateStatusCalculationSetting(statusCalc.VitalityNumericalFunctionId, baseStatus.Vitality)
        };
    }

    public static int GetCostumeExpNumericalParameterMapId(RarityType rarityType)
    {
        var table = DatabaseDefine.Master.EntityMCostumeRarityTable;
        return table.FindByRarityType(rarityType).RequiredExpForLevelUpNumericalParameterMapId;
    }

    public static int GetNumericalParameter(int numericalParameterMapId, int key)
    {
        var table = DatabaseDefine.Master.EntityMNumericalParameterMapTable;
        return table.FindByNumericalParameterMapIdAndParameterKey((numericalParameterMapId, key)).ParameterValue;
    }

    public static NumericalFunctionSetting CreatePartsMainStatusCalculationSetting(EntityMPartsStatusMain entityMPartsStatusMain)
    {
        return CreateStatusCalculationSetting(entityMPartsStatusMain.StatusNumericalFunctionId, entityMPartsStatusMain.StatusChangeInitialValue);
    }

    public static SimpleCalculationSetting CreateWeaponMaxAbilityLevelCalculationSetting(int weaponSpecificEnhanceId, RarityType rarityType)
    {
        var setting = CreateWeaponSpecificMaxAbilityLevelCalculationSetting(weaponSpecificEnhanceId);
        if (setting != null)
            return setting;

        return CreateWeaponRarityMaxAbilityLevelCalculationSetting(rarityType);
    }

    private static SimpleCalculationSetting CreateWeaponSpecificMaxAbilityLevelCalculationSetting(int weaponSpecificEnhanceId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponSpecificEnhanceTable;
        var enhance = table.FindByWeaponSpecificEnhanceId(weaponSpecificEnhanceId);
        if (enhance == null)
            return null;

        return CreateSimpleCalculationSetting(enhance.MaxAbilityLevelNumericalFunctionId);
    }

    private static SimpleCalculationSetting CreateWeaponRarityMaxAbilityLevelCalculationSetting(RarityType rarityType)
    {
        var table = DatabaseDefine.Master.EntityMWeaponRarityTable;
        var rarity = table.FindByRarityType(rarityType);

        return CreateSimpleCalculationSetting(rarity.MaxAbilityLevelNumericalFunctionId);
    }

    public static SimpleCalculationSetting CreateMaxLevelCalculationSettingOnWeaponRarity(int weaponSpecificEnhanceId, RarityType rarityType)
    {
        var setting = CreateWeaponSpecificMaxLevelCalculationSetting(weaponSpecificEnhanceId);
        if (setting != null)
            return setting;

        return CreateWeaponRarityMaxLevelCalculationSetting(rarityType);
    }

    public static SimpleCalculationSetting CreateWeaponMaxSkillLevelCalculationSetting(int weaponSpecificEnhanceId, RarityType rarityType)
    {
        var setting = CreateWeaponSpecificMaxSkillLevelCalculationSetting(weaponSpecificEnhanceId);
        if (setting != null)
            return setting;

        return CreateWeaponRarityMaxSkillLevelCalculationSetting(rarityType);
    }

    private static SimpleCalculationSetting CreateWeaponSpecificMaxSkillLevelCalculationSetting(int weaponSpecificEnhanceId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponSpecificEnhanceTable;
        var enhance = table.FindByWeaponSpecificEnhanceId(weaponSpecificEnhanceId);
        if (enhance == null)
            return null;

        return CreateSimpleCalculationSetting(enhance.MaxSkillLevelNumericalFunctionId);
    }

    private static SimpleCalculationSetting CreateWeaponRarityMaxSkillLevelCalculationSetting(RarityType rarityType)
    {
        var table = DatabaseDefine.Master.EntityMWeaponRarityTable;
        var rarity = table.FindByRarityType(rarityType);

        return CreateSimpleCalculationSetting(rarity.MaxSkillLevelNumericalFunctionId);
    }

    private static SimpleCalculationSetting CreateWeaponSpecificMaxLevelCalculationSetting(int weaponSpecificEnhanceId)
    {
        var table = DatabaseDefine.Master.EntityMWeaponSpecificEnhanceTable;
        var enhance = table.FindByWeaponSpecificEnhanceId(weaponSpecificEnhanceId);
        if (enhance == null)
            return null;

        return CreateSimpleCalculationSetting(enhance.MaxLevelNumericalFunctionId);
    }

    private static SimpleCalculationSetting CreateWeaponRarityMaxLevelCalculationSetting(RarityType rarityType)
    {
        var table = DatabaseDefine.Master.EntityMWeaponRarityTable;
        var rarity = table.FindByRarityType(rarityType);

        return CreateSimpleCalculationSetting(rarity.MaxLevelNumericalFunctionId);
    }

    public static SimpleCalculationSetting CreateCostumeActiveSkillMaxLevelCalculationSetting(RarityType rarityType)
    {
        var table = DatabaseDefine.Master.EntityMCostumeRarityTable;
        return CreateSimpleCalculationSetting(table.FindByRarityType(rarityType).ActiveSkillMaxLevelNumericalFunctionId);
    }

    public static SimpleCalculationSetting CreateSimpleCalculationSetting(int numericalFunctionId)
    {
        var numericalFunction = GetEntityMStatusCalculation(numericalFunctionId);
        var parameters = GetEntityMNumericalFunctionParameterList(numericalFunction.NumericalFunctionParameterGroupId);

        StatusCalculationFunctionParametersToArray(parameters, out var paramArray);

        return new SimpleCalculationSetting
        {
            FunctionType = numericalFunction.NumericalFunctionType,
            FunctionParameters = paramArray
        };
    }

    public static SimpleCalculationSetting CreateMaxLevelCalculationSettingOnCostumeRarity(RarityType rarityType)
    {
        var table = DatabaseDefine.Master.EntityMCostumeRarityTable;
        var costumeRarity = table.FindByRarityType(rarityType);

        return CreateSimpleCalculationSetting(costumeRarity.MaxLevelNumericalFunctionId);
    }

    private static NumericalFunctionSetting CreateStatusCalculationSetting(int statusCalculationId, int statusBaseValue)
    {
        var calc = GetEntityMStatusCalculation(statusCalculationId);
        var parameters = GetEntityMNumericalFunctionParameterList(calc.NumericalFunctionParameterGroupId);

        StatusCalculationFunctionParametersToArray(parameters, out var paramArray);

        return new NumericalFunctionSetting
        {
            BaseValue = statusBaseValue,
            NumericalFunctionType = calc.NumericalFunctionType,
            FunctionParameters = paramArray
        };
    }

    private static EntityMCostumeStatusCalculation GetEntityMBattleActorCostumeStatusCalculation(EntityMCostume entityMCostume)
    {
        var table = DatabaseDefine.Master.EntityMCostumeStatusCalculationTable;
        return table.FindByCostumeStatusCalculationId(entityMCostume.CostumeStatusCalculationId);
    }

    private static EntityMNumericalFunction GetEntityMStatusCalculation(int statusCalculationId)
    {
        var table = DatabaseDefine.Master.EntityMNumericalFunctionTable;
        return table.FindByNumericalFunctionId(statusCalculationId);
    }

    public static IReadOnlyList<EntityMNumericalFunctionParameterGroup> GetEntityMNumericalFunctionParameterList(int numericalFunctionParameterGroupId)
    {
        var table = DatabaseDefine.Master.EntityMNumericalFunctionParameterGroupTable;
        return table.FindByNumericalFunctionParameterGroupId(numericalFunctionParameterGroupId);
    }

    private static EntityMWeaponStatusCalculation GetEntityMWeaponStatusCalculation(EntityMWeapon entityMWeapon)
    {
        var table = DatabaseDefine.Master.EntityMWeaponStatusCalculationTable;
        return table.FindByWeaponStatusCalculationId(entityMWeapon.WeaponStatusCalculationId);
    }

    private static EntityMCompanionStatusCalculation GetEntityMCompanionStatusCalculation(EntityMCompanion entityMCompanion)
    {
        var table = DatabaseDefine.Master.EntityMCompanionStatusCalculationTable;
        return table.FindByCompanionStatusCalculationId(entityMCompanion.CompanionStatusCalculationId);
    }

    private static void StatusCalculationFunctionParametersToArray(IReadOnlyList<EntityMNumericalFunctionParameterGroup> source, out int[] result)
    {
        result = new int[source.Count];
        foreach (var param in source)
            result[param.ParameterIndex] = param.ParameterValue;
    }
}
