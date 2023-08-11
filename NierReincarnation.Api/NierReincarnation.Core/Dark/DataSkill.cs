using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark
{
    public class DataSkill
    {
       
        public int SkillId { get; set; }
       
        public int SlotNumber { get; set; }
       
        public string SkillName { get; set; }
       
        public string SkillDescriptionText { get; set; }
       
        public string SkillDescriptionShortText { get; set; }
       
        public int SkillLevel { get; set; }
       
        public int SkillMaxLevel { get; set; }
       
        public int AssetCategoryId { get; set; }
       
        public int AssetVariationId { get; set; }
       
        public bool IsLocked { get; }
       
        public bool IsReinforced { get; set; }
       
        public DataSkillPower DataSkillPower { get; set; }
	}
}
