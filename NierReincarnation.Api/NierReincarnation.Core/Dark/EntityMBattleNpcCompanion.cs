using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_companion")]
    public class EntityMBattleNpcCompanion
    {
        [Key(0)] // RVA: 0x1DD8160 Offset: 0x1DD8160 VA: 0x1DD8160
        public long BattleNpcId { get; set; }

        [Key(1)] // RVA: 0x1DD81A0 Offset: 0x1DD81A0 VA: 0x1DD81A0
        public string BattleNpcCompanionUuid { get; set; }

        [Key(2)] // RVA: 0x1DD81E0 Offset: 0x1DD81E0 VA: 0x1DD81E0
        public int CompanionId { get; set; }

        [Key(3)] // RVA: 0x1DD81F4 Offset: 0x1DD81F4 VA: 0x1DD81F4
        public int HeadupDisplayViewId { get; set; }

        [Key(4)] // RVA: 0x1DD8208 Offset: 0x1DD8208 VA: 0x1DD8208
        public int Level { get; set; }

        [Key(5)] // RVA: 0x1DD821C Offset: 0x1DD821C VA: 0x1DD821C
        public long AcquisitionDatetime { get; set; }
    }
}
