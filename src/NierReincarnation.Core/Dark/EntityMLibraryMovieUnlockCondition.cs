using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMLibraryMovieUnlockCondition))]
public class EntityMLibraryMovieUnlockCondition
{
    [Key(0)]
    public int LibraryMovieUnlockConditionId { get; set; }

    [Key(1)]
    public UnlockConditionType UnlockConditionType { get; set; }

    [Key(2)]
    public int ConditionValue { get; set; }
}
