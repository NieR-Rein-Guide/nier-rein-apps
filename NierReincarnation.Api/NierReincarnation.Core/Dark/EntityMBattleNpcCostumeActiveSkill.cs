using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc_costume_active_skill")]
public class EntityMBattleNpcCostumeActiveSkill
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public string BattleNpcCostumeUuid { get; set; }

    [Key(2)]
    public int Level { get; set; }

    [Key(3)]
    public long AcquisitionDatetime { get; set; }
}
