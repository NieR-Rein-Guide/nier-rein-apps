using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark;

public class DataOutgameCostume
{
    private int _actorId;

    public DataCostumeStatus CostumeStatus { get; set; }

    public DataSkill CostumeActiveSkill { get; set; }

    public DataAbility[] CostumeAbilities { get; set; }

    public int CostumeId { get; set; }

    public int CharacterId { get; set; }

    public RarityType RarityType { get; set; }

    public int LimitBreakMaterialGroupId { get; set; }

    public int CostumeActiveSkillGroupId { get; set; }

    public string CharacterName { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ActorAssetId ActorAssetId { get; set; }

    public int ActorId { set => _actorId = value; }

    public int CostumeEmblemAssetId { get; set; }

    public int CostumeLevelBonusId { get; set; }

    public int CostumeAwakenEffectGroupId { get; set; }

    public int CostumeAwakenStepMaterialGroupId { get; set; }

    public int CostumeAwakenPriceGroupId { get; set; }

    public int MaxLevel { get; set; }

    public string UserCostumeUuid { get; set; }

    public int LimitBreakCount { get; set; }

    public int Exp { get; set; }

    public long AcquisitionDatetime { get; set; }

    public int AwakenCount { get; set; }

    public int RebirthCount { get; set; }

    public StatusValue StatusValue { get; set; }

    public int Power { get; set; }

    public int Hp => StatusValue.Hp;

    public int Attack => StatusValue.Attack;

    public int Vitality => StatusValue.Vitality;

    public int Agility => StatusValue.Agility;

    public int CriticalRatioPermil => StatusValue.CriticalRatio;

    public int CriticalAttackRatioPermil => StatusValue.CriticalAttack;
}
