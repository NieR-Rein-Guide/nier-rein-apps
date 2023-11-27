using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMAbility))]
public class EntityMAbility
{
    [Key(0)]
    public int AbilityId { get; set; }

    [Key(1)]
    public int AbilityLevelGroupId { get; set; }
}
