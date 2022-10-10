using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_explore_grade_score")]
    public class EntityMExploreGradeScore
    {
        [Key(0)]
        public int ExploreId { get; set; } // 0x10
        [Key(1)]
        public int NecessaryScore { get; set; } // 0x14
        [Key(2)]
        public int ExploreGradeId { get; set; } // 0x18
    }
}