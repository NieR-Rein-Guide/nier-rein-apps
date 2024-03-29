using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserTutorialProgress))]
public class EntityIUserTutorialProgress
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public TutorialType TutorialType { get; set; }

    [Key(2)]
    public int ProgressPhase { get; set; }

    [Key(3)]
    public int ChoiceId { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
