using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark;

public class DataWeapon
{
    private int SkillAiId;
    private int ActorMovableAreaPrefabId;

    public DataWeaponStatus WeaponStatus { get; set; }

    public List<DataSkill> Skills { get; }

    public List<DataAbility> Abilities { get; }

    public List<DataAbility> BlessAbilities { get; }

    public int WeaponId { get; set; }

    public int WeaponEvolutionGroupId { get; set; }

    public int WeaponEvolutionOrder { get; set; }

    public RarityType RarityType { get; set; }

    public int MaxLevel { get; set; }

    public int WeaponSkillGroupId { get; set; }

    public int WeaponAbilityGroupId { get; set; }

    public int WeaponEvolutionMaterialGroupId { get; set; }

    public int BaseEnhancementObtainedExp { get; set; }

    public string Name { get; set; }

    public ActorAssetId ActorAssetId { get; set; }

    public int WeaponSpecificEnhanceId { get; set; }

    public int WeaponSpecificLimitBreakMaterialGroupId { get; set; }

    public bool IsRestrictDiscard { get; set; }

    public bool IsRecyclable { get; set; }

    public RarityType SeedWeaponRarityType { get; set; }

    public int EndWeaponCharacterId { get; set; }

    public bool HasAwakenRelation { get; set; }

    public int AwakenLevelLimitUp { get; set; }

    public int WeaponAwakenMaterialGroupId { get; set; }

    public int WeaponAwakenEffectGroupId { get; set; }

    public int LimitBreakCount { get; set; }

    public string UserWeaponUuid { get; set; }

    public long AcquisitionDatetime { get; set; }

    public int Exp { get; set; }

    public StatusValue StatusValue { get; set; }

    public int Power { get; set; }

    public bool IsAwaken { get; set; }

    public int ActualAwakenLevelLimitUp { get; }

    public Action<bool> OnChangeProtected { get; set; }

    public bool IsProtected { get; set; }

    public int Hp => StatusValue.Hp;

    public int Attack => StatusValue.Attack;

    public int Vitality => StatusValue.Vitality;

    public DataWeapon()
    {
        Skills = new List<DataSkill>();
        Abilities = new List<DataAbility>();
    }
}
