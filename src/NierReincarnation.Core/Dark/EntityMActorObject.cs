using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMActorObject))]
public class EntityMActorObject
{
    [Key(0)]
    public int ActorObjectId { get; set; }

    [Key(1)]
    public int ActorId { get; set; }
}
