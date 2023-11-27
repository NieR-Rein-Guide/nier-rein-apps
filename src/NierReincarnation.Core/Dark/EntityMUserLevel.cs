using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMUserLevel))]
public class EntityMUserLevel
{
    [Key(0)]
    public int UserLevel { get; set; }

    [Key(1)]
    public int MaxStamina { get; set; }
}
