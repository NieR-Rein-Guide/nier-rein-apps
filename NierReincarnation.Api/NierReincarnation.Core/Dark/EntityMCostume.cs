using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume")]
    public class EntityMCostume
    {
        [Key(0)] // RVA: 0x1DDBD1C Offset: 0x1DDBD1C VA: 0x1DDBD1C
        public int CostumeId { get; set; }  // 0x10

        [Key(1)] // RVA: 0x1DDBD5C Offset: 0x1DDBD5C VA: 0x1DDBD5C
        public int CharacterId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DDBDB0 Offset: 0x1DDBDB0 VA: 0x1DDBDB0
        public int ActorId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DDBDC4 Offset: 0x1DDBDC4 VA: 0x1DDBDC4
        public CostumeAssetCategoryType CostumeAssetCategoryType { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DDBDD8 Offset: 0x1DDBDD8 VA: 0x1DDBDD8
        public int ActorSkeletonId { get; set; }    // 0x20

        [Key(5)] // RVA: 0x1DDBDEC Offset: 0x1DDBDEC VA: 0x1DDBDEC
        public int AssetVariationId { get; set; } // 0x24

        [Key(6)] // RVA: 0x1DDBE00 Offset: 0x1DDBE00 VA: 0x1DDBE00
        public WeaponType SkillfulWeaponType { get; set; } // 0x28

        [Key(7)] // RVA: 0x1DDBE14 Offset: 0x1DDBE14 VA: 0x1DDBE14
        public RarityType RarityType { get; set; }  // 0x2C

        [Key(8)] // RVA: 0x1DDBE28 Offset: 0x1DDBE28 VA: 0x1DDBE28
        public int CostumeBaseStatusId { get; set; }    // 0x30

        [Key(9)] // RVA: 0x1DDBE3C Offset: 0x1DDBE3C VA: 0x1DDBE3C
        public int CostumeStatusCalculationId { get; set; } // 0x34

        [Key(10)] // RVA: 0x1DDBE50 Offset: 0x1DDBE50 VA: 0x1DDBE50
        public int CostumeLimitBreakMaterialGroupId { get; set; } // 0x38

        [Key(11)] // RVA: 0x1DDBE64 Offset: 0x1DDBE64 VA: 0x1DDBE64
        public int CostumeAbilityGroupId { get; set; }  // 0x3C

        [Key(12)] // RVA: 0x1DDBE78 Offset: 0x1DDBE78 VA: 0x1DDBE78
        public int CostumeActiveSkillGroupId { get; set; } // 0x40

        [Key(13)] // RVA: 0x1DDBE8C Offset: 0x1DDBE8C VA: 0x1DDBE8C
        public int CounterSkillDetailId { get; set; } // 0x44

        [Key(14)] // RVA: 0x1DDBEA0 Offset: 0x1DDBEA0 VA: 0x1DDBEA0
        public int CharacterMoverBattleActorAiId { get; set; } // 0x48

        [Key(15)] // RVA: 0x1DDBEB4 Offset: 0x1DDBEB4 VA: 0x1DDBEB4
        public int CostumeDefaultSkillGroupId { get; set; } // 0x4C

        [Key(16)] // RVA: 0x1DDBEC8 Offset: 0x1DDBEC8 VA: 0x1DDBEC8
        public int CostumeLevelBonusId { get; set; } // 0x50

        [Key(17)] // RVA: 0x1DDBEDC Offset: 0x1DDBEDC VA: 0x1DDBEDC
        public int DefaultActorSkillAiId { get; set; } // 0x54

        [Key(18)] // RVA: 0x1DDBEF0 Offset: 0x1DDBEF0 VA: 0x1DDBEF0
        public int CostumeEmblemAssetId { get; set; } // 0x58

        [Key(19)] // RVA: 0x1DDBF04 Offset: 0x1DDBF04 VA: 0x1DDBF04
        public int BattleActorSkillAiGroupId { get; set; } // 0x5C
    }
}
