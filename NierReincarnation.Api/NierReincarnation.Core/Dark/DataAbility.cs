using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark;

public class DataAbility
{
    public int AbilityId { get; set; }

    public int SlotNumber { get; set; }

    public string AbilityName { get; set; }

    public int AbilityLevel { get; set; }

    public int AbilityMaxLevel { get; set; }

    public int AbilityCategoryId { get; set; }

    public int AbilityVariationId { get; set; }

    public string AbilityDescriptionText { get; set; }

    public List<DataAbilityStatus> AbilityStatusList { get; set; }

    public List<DataSkill> PassiveSkillList { get; set; }

    public bool IsLocked { get; set; }

    public string LockTextKey { get; set; }
}
