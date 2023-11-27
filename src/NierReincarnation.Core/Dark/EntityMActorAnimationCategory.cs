using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMActorAnimationCategory))]
public class EntityMActorAnimationCategory
{
    [Key(0)]
    public int ActorAnimationCategoryId { get; set; }

    [Key(1)]
    public string Name { get; set; }
}
