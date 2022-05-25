using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark
{
    public class DataOutgameMemory
    {
        // 0x10
        public DataPartsMainStatus MainMemoryStatus { get; set; }
        // 0x18
        public DataPartsSubStatus[] SubMemoryStatus { get; set; }
        // 0x20
        public string Name { get; set; }
        // 0x28
        public string SeriesName { get; set; }
        // 0x30
        public int MemoryId { get; set; }
        // 0x34
        public int MemoryGroupId { get; set; }
        // 0x38
        public int MemorySeriesId { get; set; }
        // 0x3C
        public RarityType RarityType { get; set; }
        // 0x40
        public int MaxLevel { get; set; }
        // 0x48
        public string Description { get; set; }
        // 0x50
        public int Series { get; set; }
        // 0x54
        public int SeriesAssetId { get; set; }
        // 0x58
        public int GroupAssetId { get; set; }
        // 0x60
        public string UserMemoryUuid { get; set; }
        // 0x68
        public bool IsProtected { get; set; }
        // 0x6C
        public int Level { get; set; }
        // 0x70
        public long AcquisitionDatetime { get; set; }
        // 0x78
        public int Power { get; set; }

        public DataOutgameMemory()
        {
            SubMemoryStatus = new DataPartsSubStatus[PartsServal.SUB_STATUS_MAX_COUNT];
        }
    }
}
