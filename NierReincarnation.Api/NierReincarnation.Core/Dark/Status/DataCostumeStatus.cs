using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status;

public class DataCostumeStatus
{
    public Dictionary<StatusKindType, NumericalFunctionSetting> StatusCalculationSettings { get; set; }

    public int Level { get; set; }

    public WeaponType SkillfulWeaponType { get; set; }
}
