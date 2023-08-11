using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class TurnBattleActorSnapshot
{
    [Key(0)] // RVA: 0x1DEBA98 Offset: 0x1DEBA98 VA: 0x1DEBA98
    public ProgressDataKey ProgressDataKey { get; set; }
    [Key(1)] // RVA: 0x1DEBAAC Offset: 0x1DEBAAC VA: 0x1DEBAAC
    public ActorHash ActorHash { get; set; }

    [Key(2)] // RVA: 0x1DEBAC0 Offset: 0x1DEBAC0 VA: 0x1DEBAC0
    public bool IsActive { get; set; }
    [Key(3)] // RVA: 0x1DEBAD4 Offset: 0x1DEBAD4 VA: 0x1DEBAD4
    public bool IsAlive { get; set; }
    [Key(4)] // RVA: 0x1DEBAE8 Offset: 0x1DEBAE8 VA: 0x1DEBAE8
    public bool IsFaint { get; set; }

    [Key(5)] // RVA: 0x1DEBAFC Offset: 0x1DEBAFC VA: 0x1DEBAFC
    public int DynamicAgility { get; set; }
    [Key(6)] // RVA: 0x1DEBB10 Offset: 0x1DEBB10 VA: 0x1DEBB10
    public int DynamicAttack { get; set; }
    [Key(7)] // RVA: 0x1DEBB24 Offset: 0x1DEBB24 VA: 0x1DEBB24
    public int DynamicCriticalAttack { get; set; }
    [Key(8)] // RVA: 0x1DEBB38 Offset: 0x1DEBB38 VA: 0x1DEBB38
    public int DynamicCriticalRatio { get; set; }
    [Key(9)] // RVA: 0x1DEBB4C Offset: 0x1DEBB4C VA: 0x1DEBB4C
    public int DynamicEvasionRatio { get; set; }
    [Key(10)] // RVA: 0x1DEBB60 Offset: 0x1DEBB60 VA: 0x1DEBB60
    public int DynamicVitality { get; set; }
    [Key(11)] // RVA: 0x1DEBB74 Offset: 0x1DEBB74 VA: 0x1DEBB74
    public int DynamicHp { get; set; }
    [Key(12)] // RVA: 0x1DEBB88 Offset: 0x1DEBB88 VA: 0x1DEBB88
    public int DynamicCurrentHp { get; set; }
    [Key(13)] // RVA: 0x1DEBB9C Offset: 0x1DEBB9C VA: 0x1DEBB9C
    public int DynamicHateValue { get; set; }

    [Key(14)] // RVA: 0x1DEBBB0 Offset: 0x1DEBBB0 VA: 0x1DEBBB0
    public List<int> DefaultSkillRestrictionProbabilityList { get; set; } = new List<int>();
    [Key(15)] // RVA: 0x1DEBBC4 Offset: 0x1DEBBC4 VA: 0x1DEBBC4
    public List<int> ActiveSkillRestrictionProbabilityList { get; set; } = new List<int>();
    [Key(16)] // RVA: 0x1DEBBD8 Offset: 0x1DEBBD8 VA: 0x1DEBBD8
    public List<int> PassiveSkillRestrictionProbabilityList { get; set; } = new List<int>();

    [Key(17)] // RVA: 0x1DEBBEC Offset: 0x1DEBBEC VA: 0x1DEBBEC
    public AttributeDamageCorrectionValues AbnormalAttributeDamageCorrectionValues { get; set; } = new AttributeDamageCorrectionValues();
    [Key(18)] // RVA: 0x1DEBC00 Offset: 0x1DEBC00 VA: 0x1DEBC00
    public List<int> ActiveSkillDamageCorrectionValues { get; set; } = new List<int>();
    [Key(19)] // RVA: 0x1DEBC14 Offset: 0x1DEBC14 VA: 0x1DEBC14
    public AttributeDamageCorrectionValues AttributeDamageCorrectionValues { get; set; } = new AttributeDamageCorrectionValues();
    [Key(20)] // RVA: 0x1DEBC28 Offset: 0x1DEBC28 VA: 0x1DEBC28
    public List<int> AdditionalDamageCorrectionHpRatioValues { get; set; } = new List<int>();
    [Key(21)] // RVA: 0x1DEBC3C Offset: 0x1DEBC3C VA: 0x1DEBC3C
    public ActorBuffParameterContainer ActorBuffParameterContainer { get; set; } = new ActorBuffParameterContainer();
    [Key(22)] // RVA: 0x1DEBC50 Offset: 0x1DEBC50 VA: 0x1DEBC50
    public ContainerActorAbnormal ContainerActorAbnormal { get; set; } = new ContainerActorAbnormal();
    [Key(23)] // RVA: 0x1DEBC64 Offset: 0x1DEBC64 VA: 0x1DEBC64
    public AllDefaultSkillLotteryRatioCorrectionValues AbnormalDefaultSkillLotteryRatioCorrectionValues { get; set; } = new AllDefaultSkillLotteryRatioCorrectionValues();
    [Key(24)] // RVA: 0x1DEBC78 Offset: 0x1DEBC78 VA: 0x1DEBC78
    public AttributeDamageCorrectionValues AttributeReceiveDamageCorrectionValues { get; set; } = new AttributeDamageCorrectionValues();
    [Key(25)] // RVA: 0x1DEBC8C Offset: 0x1DEBC8C VA: 0x1DEBC8C
    public AttributeDamageCorrectionValues AbnormalAttributeReceiveDamageCorrectionValues { get; set; } = new AttributeDamageCorrectionValues();
    [Key(26)] // RVA: 0x1DEBCA0 Offset: 0x1DEBCA0 VA: 0x1DEBCA0
    public DataDamageMultiplyAlwaysList AbnormalDamageMultiplyAlwaysValues { get; set; } = new DataDamageMultiplyAlwaysList();
    [Key(27)] // RVA: 0x1DEBCB4 Offset: 0x1DEBCB4 VA: 0x1DEBCB4
    public DataDamageMultiplyHitIndexList AbnormalDamageMultiplyHitIndexValues { get; set; } = new DataDamageMultiplyHitIndexList();
    [Key(28)] // RVA: 0x1DEBCC8 Offset: 0x1DEBCC8 VA: 0x1DEBCC8
    public AbnormalResistanceValues AbnormalResistanceValues { get; set; } = new AbnormalResistanceValues();
    [Key(29)] // RVA: 0x1DEBCDC Offset: 0x1DEBCDC VA: 0x1DEBCDC
    public BuffResistanceValues BuffResistanceValues { get; set; } = new BuffResistanceValues();
    [Key(30)] // RVA: 0x1DEBCF0 Offset: 0x1DEBCF0 VA: 0x1DEBCF0
    public OverrideHitEffectValues OverrideHitEffectValues { get; set; } = new OverrideHitEffectValues();
    [Key(31)] // RVA: 0x1DEBD04 Offset: 0x1DEBD04 VA: 0x1DEBD04
    public DataModifyHateValueList AbnormalModifyHateValues { get; set; } = new DataModifyHateValueList();
    [Key(32)] // RVA: 0x1DEBD18 Offset: 0x1DEBD18 VA: 0x1DEBD18
    public DataDamageMultiplyCriticalList AbnormalDamageMultiplyCriticalValues { get; set; } = new DataDamageMultiplyCriticalList();
    [Key(33)] // RVA: 0x1DEBD2C Offset: 0x1DEBD2C VA: 0x1DEBD2C
    public DataDamageMultiplyAbnormalAttachedList AbnormalDamageMultiplyAbnormalAttachedValues { get; set; } = new DataDamageMultiplyAbnormalAttachedList();
    [Key(34)] // RVA: 0x1DEBD40 Offset: 0x1DEBD40 VA: 0x1DEBD40
    public DataDamageMultiplySkillfulWeaponList AbnormalDamageMultiplySkillfulWeaponValues { get; set; } = new DataDamageMultiplySkillfulWeaponList();
    [Key(35)] // RVA: 0x1E7584C Offset: 0x1E7584C VA: 0x1E7584C
    public DataDamageMultiplyDetailBuffAttachedList AbnormalDamageMultiplyBuffAttachedValues { get; set; } = new DataDamageMultiplyDetailBuffAttachedList();

    // RVA: 0x29BD828 Offset: 0x29BD828 VA: 0x29BD828
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
