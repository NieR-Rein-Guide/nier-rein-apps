using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark;

public class DataOutgameMemory
{
   
    public DataPartsMainStatus MainMemoryStatus { get; set; }
   
    public DataPartsSubStatus[] SubMemoryStatus { get; set; }
   
    public string Name { get; set; }
   
    public string SeriesName { get; set; }
   
    public int MemoryId { get; set; }
   
    public int MemoryGroupId { get; set; }
   
    public int MemorySeriesId { get; set; }
   
    public RarityType RarityType { get; set; }
   
    public int MaxLevel { get; set; }
   
    public string Description { get; set; }
   
    public int Series { get; set; }
   
    public int SeriesAssetId { get; set; }
   
    public int GroupAssetId { get; set; }
   
    public string UserMemoryUuid { get; set; }
   
    public bool IsProtected { get; set; }
   
    public int Level { get; set; }
   
    public long AcquisitionDatetime { get; set; }
   
    public int Power { get; set; }

    public DataOutgameMemory()
    {
        SubMemoryStatus = new DataPartsSubStatus[PartsServal.SUB_STATUS_MAX_COUNT];
    }
}
