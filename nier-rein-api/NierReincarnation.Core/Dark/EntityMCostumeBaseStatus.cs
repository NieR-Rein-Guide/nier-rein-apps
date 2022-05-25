using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_base_status")]
    public class EntityMCostumeBaseStatus
    {
        [Key(0)] // RVA: 0x1DDC2CC Offset: 0x1DDC2CC VA: 0x1DDC2CC
        public int CostumeBaseStatusId { get; set; }
        [Key(1)] // RVA: 0x1DDC30C Offset: 0x1DDC30C VA: 0x1DDC30C
        public int Hp { get; set; }
        [Key(2)] // RVA: 0x1DDC320 Offset: 0x1DDC320 VA: 0x1DDC320
        public int Attack { get; set; }
        [Key(3)] // RVA: 0x1DDC334 Offset: 0x1DDC334 VA: 0x1DDC334
        public int Vitality { get; set; }
        [Key(4)] // RVA: 0x1DDC348 Offset: 0x1DDC348 VA: 0x1DDC348
        public int Agility { get; set; }
        [Key(5)] // RVA: 0x1DDC35C Offset: 0x1DDC35C VA: 0x1DDC35C
        public int CriticalRatioPermil { get; set; }
        [Key(6)] // RVA: 0x1DDC370 Offset: 0x1DDC370 VA: 0x1DDC370
        public int CriticalAttackRatioPermil { get; set; }
        [Key(7)] // RVA: 0x1DDC384 Offset: 0x1DDC384 VA: 0x1DDC384
        public int EvasionRatioPermil { get; set; }
	}
}
