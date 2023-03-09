using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status
{
    public class DataPowerReferenceStatus
    {
        // 0x10
        public StatusKindType ReferenceStatusKindType { get; set; }
        // 0x14
        public AttributeConditionType AttributeConditionType { get; set; }
        // 0x18
        public int CoefficientValuePermil { get; set; }
    }
}
