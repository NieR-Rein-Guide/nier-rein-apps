using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc_parts_group_note")]
public class EntityMBattleNpcPartsGroupNote
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int PartsGroupId { get; set; }

    [Key(2)]
    public long FirstAcquisitionDatetime { get; set; }
}
