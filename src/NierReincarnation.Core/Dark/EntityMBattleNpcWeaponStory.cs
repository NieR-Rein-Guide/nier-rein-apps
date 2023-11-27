using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcWeaponStory))]
public class EntityMBattleNpcWeaponStory
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int WeaponId { get; set; }

    [Key(2)]
    public int ReleasedMaxStoryIndex { get; set; }
}
