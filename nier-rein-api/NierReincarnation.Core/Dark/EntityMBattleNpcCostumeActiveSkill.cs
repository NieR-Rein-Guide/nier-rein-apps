using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_costume_active_skill")]
    public class EntityMBattleNpcCostumeActiveSkill
    {
        [Key(0)] // RVA: 0x1DD8328 Offset: 0x1DD8328 VA: 0x1DD8328
        public long BattleNpcId { get; set; }
        [Key(1)] // RVA: 0x1DD8368 Offset: 0x1DD8368 VA: 0x1DD8368
        public string BattleNpcCostumeUuid { get; set; }
        [Key(2)] // RVA: 0x1DD83A8 Offset: 0x1DD83A8 VA: 0x1DD83A8
        public int Level { get; set; }
        [Key(3)] // RVA: 0x1DD83BC Offset: 0x1DD83BC VA: 0x1DD83BC
        public long AcquisitionDatetime { get; set; }
	}
}
