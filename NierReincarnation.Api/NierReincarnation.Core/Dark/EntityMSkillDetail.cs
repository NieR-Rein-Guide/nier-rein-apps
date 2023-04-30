using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_detail")]
    public class EntityMSkillDetail
    {
        [Key(0)] // RVA: 0x1DE5814 Offset: 0x1DE5814 VA: 0x1DE5814
        public int SkillDetailId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DE5854 Offset: 0x1DE5854 VA: 0x1DE5854
        public int SkillBehaviourGroupId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DE5868 Offset: 0x1DE5868 VA: 0x1DE5868
        public int NameSkillTextId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DE587C Offset: 0x1DE587C VA: 0x1DE587C
        public int SkillCooltimeValue { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DE5890 Offset: 0x1DE5890 VA: 0x1DE5890
        public int SkillCooltimeBehaviourGroupId { get; set; } // 0x20

        [Key(5)] // RVA: 0x1DE58A4 Offset: 0x1DE58A4 VA: 0x1DE58A4
        public int CasttimeFrameCount { get; set; } // 0x24

        [Key(6)] // RVA: 0x1DE58B8 Offset: 0x1DE58B8 VA: 0x1DE58B8
        public int HitRatioPermil { get; set; } // 0x28

        [Key(7)] // RVA: 0x1DE58CC Offset: 0x1DE58CC VA: 0x1DE58CC
        public int SkillRangeMilli { get; set; } // 0x2C

        [Key(8)] // RVA: 0x1DE58E0 Offset: 0x1DE58E0 VA: 0x1DE58E0
        public int SkillHitAssetCalculatorId { get; set; } // 0x30

        [Key(9)] // RVA: 0x1DE58F4 Offset: 0x1DE58F4 VA: 0x1DE58F4
        public bool IsCounterApplicable { get; set; } // 0x34

        [Key(10)] // RVA: 0x1DE5908 Offset: 0x1DE5908 VA: 0x1DE5908
        public bool IsComboCalculationTarget { get; set; } // 0x35

        [Key(11)] // RVA: 0x1DE591C Offset: 0x1DE591C VA: 0x1DE591C
        public int SkillAssetCategoryId { get; set; } // 0x38

        [Key(12)] // RVA: 0x1DE5930 Offset: 0x1DE5930 VA: 0x1DE5930
        public int SkillAssetVariationId { get; set; } // 0x3C

        [Key(13)] // RVA: 0x1DE5944 Offset: 0x1DE5944 VA: 0x1DE5944
        public int DescriptionSkillTextId { get; set; } // 0x40

        [Key(14)] // RVA: 0x1DE5958 Offset: 0x1DE5958 VA: 0x1DE5958
        public SkillActType SkillActType { get; set; } // 0x44

        [Key(15)] // RVA: 0x1DE596C Offset: 0x1DE596C VA: 0x1DE596C
        public int SkillHitCount { get; set; } // 0x48

        [Key(16)] // RVA: 0x1DE5980 Offset: 0x1DE5980 VA: 0x1DE5980
        public int SkillPowerBaseValue { get; set; } // 0x4C

        [Key(17)] // RVA: 0x1DE5994 Offset: 0x1DE5994 VA: 0x1DE5994
        public PowerCalculationReferenceStatusType PowerCalculationReferenceStatusType { get; set; } // 0x50

        [Key(18)] // RVA: 0x1DE59A8 Offset: 0x1DE59A8 VA: 0x1DE59A8
        public int PowerReferenceStatusGroupId { get; set; } // 0x54

        [Key(19)] // RVA: 0x1DE59BC Offset: 0x1DE59BC VA: 0x1DE59BC
        public int SkillCasttimeId { get; set; } // 0x58
    }
}
