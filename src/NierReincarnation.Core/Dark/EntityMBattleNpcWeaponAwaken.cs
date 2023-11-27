using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcWeaponAwaken))]
public class EntityMBattleNpcWeaponAwaken
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public string BattleNpcWeaponUuid { get; set; }
}
