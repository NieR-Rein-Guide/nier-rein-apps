using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_display_coordinate_adjustment")]
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
