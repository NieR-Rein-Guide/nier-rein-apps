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
        public int LibraryMovieUnlockConditionId { get; set; }

        [Key(1)]
        public UnlockConditionType UnlockConditionType { get; set; }

        [Key(2)]
        public int ConditionValue { get; set; }
    }
}
