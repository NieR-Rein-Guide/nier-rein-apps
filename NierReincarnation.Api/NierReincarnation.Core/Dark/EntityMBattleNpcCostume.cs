using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_costume")]
    public class EntityMBattleNpcCostume
    {
        [Key(0)] // RVA: 0x1DD8230 Offset: 0x1DD8230 VA: 0x1DD8230
        public long BattleNpcId { get; set; }

        [Key(1)] // RVA: 0x1DD8270 Offset: 0x1DD8270 VA: 0x1DD8270
        public string BattleNpcCostumeUuid { get; set; }

        [Key(2)] // RVA: 0x1DD82B0 Offset: 0x1DD82B0 VA: 0x1DD82B0
        public int CostumeId { get; set; }

        [Key(3)] // RVA: 0x1DD82C4 Offset: 0x1DD82C4 VA: 0x1DD82C4
        public int LimitBreakCount { get; set; }

        [Key(4)] // RVA: 0x1DD82D8 Offset: 0x1DD82D8 VA: 0x1DD82D8
        public int Level { get; set; }

        [Key(5)] // RVA: 0x1DD82EC Offset: 0x1DD82EC VA: 0x1DD82EC
        public int Exp { get; set; }

        [Key(6)] // RVA: 0x1DD8300 Offset: 0x1DD8300 VA: 0x1DD8300
        public int HeadupDisplayViewId { get; set; }

        [Key(7)] // RVA: 0x1DD8314 Offset: 0x1DD8314 VA: 0x1DD8314
        public long AcquisitionDatetime { get; set; }

        [Key(8)] // RVA: 0x1E99C00 Offset: 0x1E99C00 VA: 0x1E99C00
        public int AwakenCount { get; set; }
    }
}
