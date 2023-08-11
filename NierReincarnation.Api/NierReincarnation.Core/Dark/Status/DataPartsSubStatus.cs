using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status
{
    public class DataPartsSubStatus
    {
        private int _statusLevel;

        public int StatusLevel { set => _statusLevel = value; }
        public StatusKindType StatusKindType { get; set; }
        public StatusCalculationType StatusCalculationType { get; set; }
        public int StatusChangeValue { get; set; }
    }
}
