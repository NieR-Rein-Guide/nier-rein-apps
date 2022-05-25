using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_material")]
    public class EntityMMaterial
    {
        [Key(0)] // RVA: 0x1DF2EE0 Offset: 0x1DF2EE0 VA: 0x1DF2EE0
        public int MaterialId { get; set; }
        [Key(1)] // RVA: 0x1DF2F20 Offset: 0x1DF2F20 VA: 0x1DF2F20
        public MaterialType MaterialType { get; set; }
        [Key(2)] // RVA: 0x1DF2F34 Offset: 0x1DF2F34 VA: 0x1DF2F34
        public RarityType RarityType { get; set; }
        [Key(3)] // RVA: 0x1DF2F48 Offset: 0x1DF2F48 VA: 0x1DF2F48
        public WeaponType WeaponType { get; set; }
        [Key(4)] // RVA: 0x1DF2F5C Offset: 0x1DF2F5C VA: 0x1DF2F5C
        public AttributeType AttributeType { get; set; }
        [Key(5)] // RVA: 0x1DF2F70 Offset: 0x1DF2F70 VA: 0x1DF2F70
        public int EffectValue { get; set; }
        [Key(6)] // RVA: 0x1DF2F84 Offset: 0x1DF2F84 VA: 0x1DF2F84
        public int SellPrice { get; set; }
        [Key(7)] // RVA: 0x1DF2F98 Offset: 0x1DF2F98 VA: 0x1DF2F98
        public string AssetName { get; set; }
        [Key(8)] // RVA: 0x1DF2FAC Offset: 0x1DF2FAC VA: 0x1DF2FAC
        public int AssetCategoryId { get; set; }
        [Key(9)] // RVA: 0x1DF2FC0 Offset: 0x1DF2FC0 VA: 0x1DF2FC0
        public int AssetVariationId { get; set; }
        [Key(10)] // RVA: 0x1DF2FD4 Offset: 0x1DF2FD4 VA: 0x1DF2FD4
        public int MaterialSaleObtainPossessionId { get; set; }
	}
}
