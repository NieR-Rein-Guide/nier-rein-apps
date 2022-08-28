using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_display_coordinate_adjustment")]
    public class EntityMCostumeDisplayCoordinateAdjustment
    {
        [Key(0)]
        public int CostumeId { get; set; } // 0x10
        [Key(1)]
        public int DisplayCoordinateAdjustmentFunctionType { get; set; } // 0x14
        [Key(2)]
        public int HorizontalCoordinateCountPermil { get; set; } // 0x18
        [Key(3)]
        public int VerticalCoordinateCountPermil { get; set; } // 0x1C
    }
}