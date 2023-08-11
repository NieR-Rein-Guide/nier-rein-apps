using NierReincarnation.Core.Dark.Generated.Type;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Status;

public class DataWeaponStatus
{
   
    public Dictionary<StatusKindType, NumericalFunctionSetting> StatusCalculationSettings { get; set; }

   
    public int Level { get; set; }

   
    public AttributeType AttributeType { get; set; }

   
    public WeaponType WeaponType { get; set; }

   
    public List<DataWeaponAwakenStatus> WeaponAwakenStatusList { get; set; }
}
