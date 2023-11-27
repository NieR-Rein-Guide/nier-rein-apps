using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcDeckSubWeaponGroup))]
public class EntityMBattleNpcDeckSubWeaponGroup
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public string BattleNpcDeckCharacterUuid { get; set; }

    [Key(2)]
    public string BattleNpcWeaponUuid { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }
}
