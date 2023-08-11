using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc")]
public class EntityMBattleNpc
{
    [Key(0)]
    public long BattleNpcId { get; set; }
}
