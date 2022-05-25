using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark
{
    public class DataSkill
    {
        // 0x10
        public int SkillId { get; set; }
        // 0x14
        public int SlotNumber { get; set; }
        // 0x18
        public string SkillName { get; set; }
        // 0x20
        public string SkillDescriptionText { get; set; }
        // 0x28
        public string SkillDescriptionShortText { get; set; }
        // 0x30
        public int SkillLevel { get; set; }
        // 0x34
        public int SkillMaxLevel { get; set; }
        // 0x38
        public int AssetCategoryId { get; set; }
        // 0x3C
        public int AssetVariationId { get; set; }
        // 0x40
        public bool IsLocked { get; }
        // 0x41
        public bool IsReinforced { get; set; }
        // 0x48
        public DataSkillPower DataSkillPower { get; set; }
	}
}
