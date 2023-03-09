using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status
{
    public class DataCostumeStatus
    {
        // 0x10
        public Dictionary<StatusKindType, NumericalFunctionSetting> StatusCalculationSettings { get; set; }
        // 0x18
        public int Level { get; set; }
        // 0x1C
        public WeaponType SkillfulWeaponType { get; set; }
    }
}
