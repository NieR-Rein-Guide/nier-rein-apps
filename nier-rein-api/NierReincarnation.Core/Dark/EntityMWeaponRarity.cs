using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_rarity")]
    public class EntityMWeaponRarity
    {
        [Key(0)] // RVA: 0x1DE6DA4 Offset: 0x1DE6DA4 VA: 0x1DE6DA4
        public RarityType RarityType { get; set; }
        [Key(1)] // RVA: 0x1DE6DE4 Offset: 0x1DE6DE4 VA: 0x1DE6DE4
        public int BaseEnhancementObtainedExp { get; set; }
        [Key(2)] // RVA: 0x1DE6DF8 Offset: 0x1DE6DF8 VA: 0x1DE6DF8
        public int SellPriceNumericalFunctionId { get; set; }
        [Key(3)] // RVA: 0x1DE6E0C Offset: 0x1DE6E0C VA: 0x1DE6E0C
        public int MaxLevelNumericalFunctionId { get; set; }
        [Key(4)] // RVA: 0x1DE6E20 Offset: 0x1DE6E20 VA: 0x1DE6E20
        public int MaxSkillLevelNumericalFunctionId { get; set; }
        [Key(5)] // RVA: 0x1DE6E34 Offset: 0x1DE6E34 VA: 0x1DE6E34
        public int MaxAbilityLevelNumericalFunctionId { get; set; }
        [Key(6)] // RVA: 0x1DE6E48 Offset: 0x1DE6E48 VA: 0x1DE6E48
        public int RequiredExpForLevelUpNumericalParameterMapId { get; set; }
        [Key(7)] // RVA: 0x1DE6E5C Offset: 0x1DE6E5C VA: 0x1DE6E5C
        public int EnhancementCostByWeaponNumericalFunctionId { get; set; }
        [Key(8)] // RVA: 0x1DE6E70 Offset: 0x1DE6E70 VA: 0x1DE6E70
        public int EnhancementCostByMaterialNumericalFunctionId { get; set; }
        [Key(9)] // RVA: 0x1DE6E84 Offset: 0x1DE6E84 VA: 0x1DE6E84
        public int SkillEnhancementCostNumericalFunctionId { get; set; }
        [Key(10)] // RVA: 0x1DE6E98 Offset: 0x1DE6E98 VA: 0x1DE6E98
        public int AbilityEnhancementCostNumericalFunctionId { get; set; }
        [Key(11)] // RVA: 0x1DE6EAC Offset: 0x1DE6EAC VA: 0x1DE6EAC
        public int LimitBreakCostByWeaponNumericalFunctionId { get; set; }
        [Key(12)] // RVA: 0x1DE6EC0 Offset: 0x1DE6EC0 VA: 0x1DE6EC0
        public int LimitBreakCostByMaterialNumericalFunctionId { get; set; }
        [Key(13)] // RVA: 0x1DE6ED4 Offset: 0x1DE6ED4 VA: 0x1DE6ED4
        public int EvolutionCostNumericalFunctionId { get; set; }
	}
}
