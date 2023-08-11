using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc_deck_sub_weapon_group")]
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
