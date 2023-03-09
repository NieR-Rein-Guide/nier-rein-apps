using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark
{
    public class DataOutgameCostume
    {
        private int _actorId;

        // 0x10
        public DataCostumeStatus CostumeStatus { get; set; }
        // 0x18
        public DataSkill CostumeActiveSkill { get; set; }
        // 0x20
        public DataAbility[] CostumeAbilities { get; set; }
        // 0x28
        public int CostumeId { get; set; }
        // 0x2C
        public int CharacterId { get; set; }
        // 0x30
        public RarityType RarityType { get; set; }
        // 0x34
        public int LimitBreakMaterialGroupId { get; set; }
        // 0x38
        public int CostumeActiveSkillGroupId { get; set; }
        // 0x40
        public string CharacterName { get; set; }
        // 0x48
        public string Name { get; set; }
        // 0x50
        public string Description { get; set; }
        // 0x58
        public ActorAssetId ActorAssetId { get; set; }
        // 0x60
        public int ActorId { set => _actorId = value; }
        // 0x64
        public int CostumeEmblemAssetId { get; set; }
        // 0x68
        public int CostumeLevelBonusId { get; set; }
        // 0x6C
        public int CostumeAwakenEffectGroupId { get; set; }
        // 0x70
        public int CostumeAwakenStepMaterialGroupId { get; set; }
        // 0x74
        public int CostumeAwakenPriceGroupId { get; set; }
        // 0x78
        public int MaxLevel { get; set; }
        // 0x80
        public string UserCostumeUuid { get; set; }
        // 0x88
        public int LimitBreakCount { get; set; }
        // 0x8C
        public int Exp { get; set; }
        // 0x90
        public long AcquisitionDatetime { get; set; }
        // 0x98
        public int AwakenCount { get; set; }
        // 0x9C
        public int RebirthCount { get; set; }
        // 0xA0
        public StatusValue StatusValue { get; set; }

        // 0xBC
        public int Power { get; set; }

        public int Hp => StatusValue.Hp;
        public int Attack => StatusValue.Attack;
        public int Vitality => StatusValue.Vitality;
        public int Agility => StatusValue.Agility;
        public int CriticalRatioPermil => StatusValue.CriticalRatio;
        public int CriticalAttackRatioPermil => StatusValue.CriticalAttack;
    }
}
