using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_base_status")]
    public class EntityMCostumeBaseStatus
    {
        [Key(0)] // RVA: 0x1DDC2CC Offset: 0x1DDC2CC VA: 0x1DDC2CC
        public int CostumeBaseStatusId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DDC30C Offset: 0x1DDC30C VA: 0x1DDC30C
        public int Hp { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DDC320 Offset: 0x1DDC320 VA: 0x1DDC320
        public int Attack { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DDC334 Offset: 0x1DDC334 VA: 0x1DDC334
        public int Vitality { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DDC348 Offset: 0x1DDC348 VA: 0x1DDC348
        public int Agility { get; set; } // 0x20

        [Key(5)] // RVA: 0x1DDC35C Offset: 0x1DDC35C VA: 0x1DDC35C
        public int CriticalRatioPermil { get; set; } // 0x24

        [Key(6)] // RVA: 0x1DDC370 Offset: 0x1DDC370 VA: 0x1DDC370
        public int CriticalAttackRatioPermil { get; set; } // 0x28

        [Key(7)] // RVA: 0x1DDC384 Offset: 0x1DDC384 VA: 0x1DDC384
        public int EvasionRatioPermil { get; set; } // 0x2C
    }
}
