using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc_character")]
public class EntityMBattleNpcCharacter
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int Level { get; set; }

    [Key(3)]
    public int Exp { get; set; }
}