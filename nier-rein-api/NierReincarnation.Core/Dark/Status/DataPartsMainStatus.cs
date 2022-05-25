using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status
{
    public class DataPartsMainStatus
    {
        // 0x10
        public StatusKindType StatusKindType { get; set; }
        // 0x14
        public StatusCalculationType StatusCalculationType { get; set; }
        // 0x18
        public NumericalFunctionSetting NumericalFunctionSetting { get; set; }
        // 0x20
        public int Level { get; set; }
    }
}
