using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon")]
    public class EntityMWeapon
    {
        [Key(0)] // RVA: 0x1DE663C Offset: 0x1DE663C VA: 0x1DE663C
        public int WeaponId { get; set; }

        [Key(1)] // RVA: 0x1DE667C Offset: 0x1DE667C VA: 0x1DE667C
        public int WeaponCategoryType { get; set; }

        [Key(2)] // RVA: 0x1DE6690 Offset: 0x1DE6690 VA: 0x1DE6690
        public WeaponType WeaponType { get; set; } 

        [Key(3)] // RVA: 0x1DE66A4 Offset: 0x1DE66A4 VA: 0x1DE66A4
        public int AssetVariationId { get; set; }

        [Key(4)] // RVA: 0x1DE66B8 Offset: 0x1DE66B8 VA: 0x1DE66B8
        public RarityType RarityType { get; set; }

        [Key(5)] // RVA: 0x1DE66CC Offset: 0x1DE66CC VA: 0x1DE66CC
        public AttributeType AttributeType { get; set; }

        [Key(6)] // RVA: 0x1DE66E0 Offset: 0x1DE66E0 VA: 0x1DE66E0
        public bool IsRestrictDiscard { get; set; }

        [Key(7)] // RVA: 0x1DE66F4 Offset: 0x1DE66F4 VA: 0x1DE66F4
        public int WeaponBaseStatusId { get; set; }

        [Key(8)] // RVA: 0x1DE6708 Offset: 0x1DE6708 VA: 0x1DE6708
        public int WeaponStatusCalculationId { get; set; }

        [Key(9)] // RVA: 0x1DE671C Offset: 0x1DE671C VA: 0x1DE671C
        public int WeaponSkillGroupId { get; set; }

        [Key(10)] // RVA: 0x1DE6730 Offset: 0x1DE6730 VA: 0x1DE6730
        public int WeaponAbilityGroupId { get; set; }

        [Key(11)] // RVA: 0x1DE6744 Offset: 0x1DE6744 VA: 0x1DE6744
        public int WeaponEvolutionMaterialGroupId { get; set; }

        [Key(12)] // RVA: 0x1DE6758 Offset: 0x1DE6758 VA: 0x1DE6758
        public int WeaponEvolutionGrantPossessionGroupId { get; set; }

        [Key(13)] // RVA: 0x1DE676C Offset: 0x1DE676C VA: 0x1DE676C
        public int WeaponStoryReleaseConditionGroupId { get; set; }

        [Key(14)] // RVA: 0x1DE6780 Offset: 0x1DE6780 VA: 0x1DE6780
        public int WeaponSpecificEnhanceId { get; set; }

        [Key(15)] // RVA: 0x1DE6794 Offset: 0x1DE6794 VA: 0x1DE6794
        public int WeaponSpecificLimitBreakMaterialGroupId { get; set; }

        [Key(16)] // RVA: 0x1DE67A8 Offset: 0x1DE67A8 VA: 0x1DE67A8
        public int CharacterWalkaroundRangeType { get; set; }

        [Key(17)] // RVA: 0x1F826FC Offset: 0x1F826FC VA: 0x1F826FC
        public bool IsRecyclable { get; set; }
    }
}
