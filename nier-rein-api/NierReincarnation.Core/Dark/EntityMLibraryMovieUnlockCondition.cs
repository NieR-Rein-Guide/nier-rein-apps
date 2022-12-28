using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_library_movie_unlock_condition")]
    public class EntityMLibraryMovieUnlockCondition
    {
        [Key(0)]
        public int LibraryMovieUnlockConditionId { get; set; } // 0x10
        [Key(1)]
        public UnlockConditionType UnlockConditionType { get; set; } // 0x14
        [Key(2)]
        public int ConditionValue { get; set; } // 0x18
    }
}