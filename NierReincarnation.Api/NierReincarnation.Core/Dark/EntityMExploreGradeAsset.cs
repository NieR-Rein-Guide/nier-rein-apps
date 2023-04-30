using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_explore_grade_asset")]
    public class EntityMExploreGradeAsset
    {
        [Key(0)]
        public int ExploreGradeId { get; set; } // 0x10

        [Key(1)]
        public int AssetGradeIconId { get; set; } // 0x14
    }
}
