using NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class TurnBattleActorSnapshot
{
    [Key(0)]
    public ProgressDataKey ProgressDataKey { get; set; }

    [Key(1)]
    public ActorHash ActorHash { get; set; }

    [Key(2)]
    public bool IsActive { get; set; }

    [Key(3)]
    public bool IsAlive { get; set; }

    [Key(4)]
    public bool IsFaint { get; set; }

    [Key(5)]
    public int DynamicAgility { get; set; }

    [Key(6)]
    public int DynamicAttack { get; set; }

    [Key(7)]
    public int DynamicCriticalAttack { get; set; }

    [Key(8)]
    public int DynamicCriticalRatio { get; set; }

    [Key(9)]
    public int DynamicEvasionRatio { get; set; }

    [Key(10)]
    public int DynamicVitality { get; set; }

    [Key(11)]
    public int DynamicHp { get; set; }

    [Key(12)]
    public int DynamicCurrentHp { get; set; }

    [Key(13)]
    public int DynamicHateValue { get; set; }

    [Key(14)]
    public List<int> DefaultSkillRestrictionProbabilityList { get; set; } = new List<int>();

    [Key(15)]
    public List<int> ActiveSkillRestrictionProbabilityList { get; set; } = new List<int>();

    [Key(16)]
    public List<int> PassiveSkillRestrictionProbabilityList { get; set; } = new List<int>();

    [Key(17)]
    public AttributeDamageCorrectionValues AbnormalAttributeDamageCorrectionValues { get; set; } = new AttributeDamageCorrectionValues();

    [Key(18)]
    public List<int> ActiveSkillDamageCorrectionValues { get; set; } = new List<int>();

    [Key(19)]
    public AttributeDamageCorrectionValues AttributeDamageCorrectionValues { get; set; } = new AttributeDamageCorrectionValues();

    [Key(20)]
    public List<int> AdditionalDamageCorrectionHpRatioValues { get; set; } = new List<int>();

    [Key(21)]
    public ActorBuffParameterContainer ActorBuffParameterContainer { get; set; } = new ActorBuffParameterContainer();

    [Key(22)]
    public ContainerActorAbnormal ContainerActorAbnormal { get; set; } = new ContainerActorAbnormal();

    [Key(23)]
    public AllDefaultSkillLotteryRatioCorrectionValues AbnormalDefaultSkillLotteryRatioCorrectionValues { get; set; } = new AllDefaultSkillLotteryRatioCorrectionValues();

    [Key(24)]
    public AttributeDamageCorrectionValues AttributeReceiveDamageCorrectionValues { get; set; } = new AttributeDamageCorrectionValues();

    [Key(25)]
    public AttributeDamageCorrectionValues AbnormalAttributeReceiveDamageCorrectionValues { get; set; } = new AttributeDamageCorrectionValues();

    [Key(26)]
    public DataDamageMultiplyAlwaysList AbnormalDamageMultiplyAlwaysValues { get; set; } = new DataDamageMultiplyAlwaysList();

    [Key(27)]
    public DataDamageMultiplyHitIndexList AbnormalDamageMultiplyHitIndexValues { get; set; } = new DataDamageMultiplyHitIndexList();

    [Key(28)]
    public AbnormalResistanceValues AbnormalResistanceValues { get; set; } = new AbnormalResistanceValues();

    [Key(29)]
    public BuffResistanceValues BuffResistanceValues { get; set; } = new BuffResistanceValues();

    [Key(30)]
    public OverrideHitEffectValues OverrideHitEffectValues { get; set; } = new OverrideHitEffectValues();

    [Key(31)]
    public DataModifyHateValueList AbnormalModifyHateValues { get; set; } = new DataModifyHateValueList();

    [Key(32)]
    public DataDamageMultiplyCriticalList AbnormalDamageMultiplyCriticalValues { get; set; } = new DataDamageMultiplyCriticalList();

    [Key(33)]
    public DataDamageMultiplyAbnormalAttachedList AbnormalDamageMultiplyAbnormalAttachedValues { get; set; } = new DataDamageMultiplyAbnormalAttachedList();

    [Key(34)]
    public DataDamageMultiplySkillfulWeaponList AbnormalDamageMultiplySkillfulWeaponValues { get; set; } = new DataDamageMultiplySkillfulWeaponList();

    [Key(35)]
    public DataDamageMultiplyDetailBuffAttachedList AbnormalDamageMultiplyBuffAttachedValues { get; set; } = new DataDamageMultiplyDetailBuffAttachedList();

    public static ProgressDataKey GenerateProgressDataKey(ActorHash actorHash, int waveNumber)
    {
        return new ProgressDataKey
        {
            Key0 = 1,
            Key1 = actorHash.hash,
            Key2 = waveNumber
        };
    }
}
