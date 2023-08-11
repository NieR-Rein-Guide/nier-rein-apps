using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_specific_enhance")]
    public class EntityMWeaponSpecificEnhance
    {
        [Key(0)] // RVA: 0x1DE7120 Offset: 0x1DE7120 VA: 0x1DE7120
        public int WeaponSpecificEnhanceId { get; set; }

        [Key(1)] // RVA: 0x1DE7160 Offset: 0x1DE7160 VA: 0x1DE7160
        public int BaseEnhancementObtainedExp { get; set; }

        [Key(2)] // RVA: 0x1DE7174 Offset: 0x1DE7174 VA: 0x1DE7174
        public int SellPriceNumericalFunctionId { get; set; }

        [Key(3)] // RVA: 0x1DE7188 Offset: 0x1DE7188 VA: 0x1DE7188
        public int MaxLevelNumericalFunctionId { get; set; }

        [Key(4)] // RVA: 0x1DE719C Offset: 0x1DE719C VA: 0x1DE719C
        public int MaxSkillLevelNumericalFunctionId { get; set; }

        [Key(5)] // RVA: 0x1DE71B0 Offset: 0x1DE71B0 VA: 0x1DE71B0
        public int MaxAbilityLevelNumericalFunctionId { get; set; }

        [Key(6)] // RVA: 0x1DE71C4 Offset: 0x1DE71C4 VA: 0x1DE71C4
        public int RequiredExpForLevelUpNumericalParameterMapId { get; set; }

        [Key(7)] // RVA: 0x1DE71D8 Offset: 0x1DE71D8 VA: 0x1DE71D8
        public int EnhancementCostByWeaponNumericalFunctionId { get; set; }

        [Key(8)] // RVA: 0x1DE71EC Offset: 0x1DE71EC VA: 0x1DE71EC
        public int EnhancementCostByMaterialNumericalFunctionId { get; set; }

        [Key(9)] // RVA: 0x1DE7200 Offset: 0x1DE7200 VA: 0x1DE7200
        public int SkillEnhancementCostNumericalFunctionId { get; set; }

        [Key(10)] // RVA: 0x1DE7214 Offset: 0x1DE7214 VA: 0x1DE7214
        public int AbilityEnhancementCostNumericalFunctionId { get; set; }

        [Key(11)] // RVA: 0x1DE7228 Offset: 0x1DE7228 VA: 0x1DE7228
        public int LimitBreakCostByWeaponNumericalFunctionId { get; set; }

        [Key(12)] // RVA: 0x1DE723C Offset: 0x1DE723C VA: 0x1DE723C
        public int LimitBreakCostByMaterialNumericalFunctionId { get; set; }

        [Key(13)] // RVA: 0x1DE7250 Offset: 0x1DE7250 VA: 0x1DE7250
        public int EvolutionCostNumericalFunctionId { get; set; }
    }
}
