using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Datamine.Model;

public class UserMemoir
{
    public string SeriesName { get; init; }

    public string Name { get; init; }

    public string SmallSet { get; init; }

    public string LargeSet { get; init; }

    public DateTimeOffset AcquisitionDateTimeOffset { get; init; }

    public decimal Agility { get; init; }

    public decimal AttackFlat { get; init; }

    public decimal AttackPercent { get; init; }

    public decimal HpFlat { get; init; }

    public decimal HpPercent { get; init; }

    public decimal DefenseFlat { get; init; }

    public decimal DefencePercent { get; init; }

    public decimal EvasionRate { get; init; }

    public decimal CriticalDamage { get; init; }

    public decimal CriticalRate { get; init; }

    public UserMemoir(DataOutgameMemory darkUserMemoirData)
    {
        Name = darkUserMemoirData.Name;
        SeriesName = darkUserMemoirData.SeriesName;

        AcquisitionDateTimeOffset = CalculatorDateTime.FromUnixTime(darkUserMemoirData.AcquisitionDatetime);

        Agility = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.AGILITY, StatusCalculationType.ADD) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.AGILITY, StatusCalculationType.ADD, x.StatusChangeValue));

        AttackFlat = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.ATTACK, StatusCalculationType.ADD) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.ATTACK, StatusCalculationType.ADD, x.StatusChangeValue));

        AttackPercent = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.ATTACK, StatusCalculationType.MULTIPLY) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.ATTACK, StatusCalculationType.MULTIPLY, x.StatusChangeValue));

        HpFlat = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.HP, StatusCalculationType.ADD) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.HP, StatusCalculationType.ADD, x.StatusChangeValue));

        HpPercent = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.HP, StatusCalculationType.MULTIPLY) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.HP, StatusCalculationType.MULTIPLY, x.StatusChangeValue));

        DefenseFlat = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.VITALITY, StatusCalculationType.ADD) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.VITALITY, StatusCalculationType.ADD, x.StatusChangeValue));

        DefencePercent = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.VITALITY, StatusCalculationType.MULTIPLY) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.VITALITY, StatusCalculationType.MULTIPLY, x.StatusChangeValue));

        EvasionRate = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.EVASION_RATIO, StatusCalculationType.ADD) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.EVASION_RATIO, StatusCalculationType.ADD, x.StatusChangeValue));

        CriticalDamage = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.CRITICAL_ATTACK, StatusCalculationType.ADD) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.CRITICAL_ATTACK, StatusCalculationType.ADD, x.StatusChangeValue));

        CriticalRate = GetMainStatValue(darkUserMemoirData.MainMemoryStatus, darkUserMemoirData.RarityType, StatusKindType.CRITICAL_RATIO, StatusCalculationType.ADD) +
            darkUserMemoirData.SubMemoryStatus.Sum(x => GetSubStatValue(x, StatusKindType.CRITICAL_RATIO, StatusCalculationType.ADD, x.StatusChangeValue));
    }

    public static decimal GetMainStatValue(DataPartsMainStatus mainStat, RarityType rarityType, StatusKindType statusKindType, StatusCalculationType statusCalculationType)
    {
        if (mainStat.StatusKindType != statusKindType || mainStat.StatusCalculationType != statusCalculationType)
        {
            return 0;
        }

        // Proper solution, doesn't work for flat value main stats
        //var value = PartsServal.calcStatusDiffByMainOption(mainStat.Level, mainStat.NumericalFunctionSetting.BaseValue,
        //    mainStat.NumericalFunctionSetting.NumericalFunctionType, mainStat.NumericalFunctionSetting.FunctionParameters);

        //return statusKindType switch
        //{
        //    StatusKindType.AGILITY => value,
        //    StatusKindType.ATTACK or StatusKindType.HP or StatusKindType.VITALITY => statusCalculationType == StatusCalculationType.ADD ? value : value / 10.0M,
        //    StatusKindType.CRITICAL_ATTACK or StatusKindType.CRITICAL_RATIO => value / 10.0M,
        //    _ => 0
        //};

        if (statusCalculationType == StatusCalculationType.ADD)
        {
            return statusKindType switch
            {
                StatusKindType.AGILITY => rarityType == RarityType.SS_RARE ? 120 : 90,
                StatusKindType.ATTACK or StatusKindType.VITALITY => rarityType == RarityType.SS_RARE ? 600 : 450,
                StatusKindType.HP => rarityType == RarityType.SS_RARE ? 6900 : 4500,
                StatusKindType.CRITICAL_ATTACK => rarityType == RarityType.SS_RARE ? 25 : 16,
                StatusKindType.CRITICAL_RATIO => rarityType == RarityType.SS_RARE ? 20 : 15,
                _ => 0
            };
        }
        else
        {
            return statusKindType switch
            {
                StatusKindType.ATTACK or StatusKindType.HP or StatusKindType.VITALITY => rarityType == RarityType.SS_RARE ? 20 : 15,
                _ => 0
            };
        }
    }

    public static decimal GetSubStatValue(DataPartsSubStatus subStat, StatusKindType statusKindType, StatusCalculationType statusCalculationType, int value)
    {
        if (subStat.StatusKindType != statusKindType || subStat.StatusCalculationType != statusCalculationType)
        {
            return 0;
        }

        return statusKindType switch
        {
            StatusKindType.AGILITY => value,
            StatusKindType.ATTACK or StatusKindType.HP or StatusKindType.VITALITY => statusCalculationType == StatusCalculationType.ADD ? value : value / 10.0M,
            StatusKindType.CRITICAL_ATTACK or StatusKindType.CRITICAL_RATIO => value / 10.0M,
            _ => 0
        };
    }
}
