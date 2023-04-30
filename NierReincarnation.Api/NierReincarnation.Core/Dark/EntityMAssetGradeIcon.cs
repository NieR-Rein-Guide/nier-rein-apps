using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_asset_grade_icon")]
    public class EntityMAssetGradeIcon
    {
        [Key(0)]
        public int AssetGradeIconId { get; set; } // 0x10

        [Key(1)]
        public int AssetId { get; set; } // 0x14

        [Key(2)]
        public int Level { get; set; } // 0x18

        [Key(3)]
        public int SeAssetId { get; set; } // 0x1C
    }
}
