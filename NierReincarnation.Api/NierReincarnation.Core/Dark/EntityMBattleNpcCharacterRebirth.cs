using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc_character_rebirth")]
public class EntityMBattleNpcCharacterRebirth
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int RebirthCount { get; set; }
}
