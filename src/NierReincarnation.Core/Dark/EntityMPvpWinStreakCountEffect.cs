using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPvpWinStreakCountEffect))]
public class EntityMPvpWinStreakCountEffect
{
    [Key(0)]
    public int WinStreakCount { get; set; }

    [Key(1)]
    public int AbilityId { get; set; }

    [Key(2)]
    public int AbilityLevel { get; set; }
}
