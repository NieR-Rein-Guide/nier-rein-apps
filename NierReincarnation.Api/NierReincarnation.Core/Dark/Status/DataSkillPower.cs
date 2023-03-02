using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status
{
    public class DataSkillPower
    {
        // 0x10
        public List<DataPowerReferenceStatus> ReferenceStatusSettings { get; set; }
        // 0x18
        public int SkillPowerBaseValue { get; set; }
        // 0x1C
        public PowerCalculationReferenceStatusType ReferenceStatusType { get; set; }
    }
}
