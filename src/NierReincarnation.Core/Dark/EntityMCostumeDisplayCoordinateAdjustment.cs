using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeDisplayCoordinateAdjustment))]
public class EntityMCostumeDisplayCoordinateAdjustment
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public DisplayCoordinateAdjustmentFunctionType DisplayCoordinateAdjustmentFunctionType { get; set; }

    [Key(2)]
    public int HorizontalCoordinateCountPermil { get; set; }

    [Key(3)]
    public int VerticalCoordinateCountPermil { get; set; }
}
