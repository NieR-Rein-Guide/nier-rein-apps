using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark
{
    public class DataOutgameCompanion
    {
        // 0x10
        public DataCompanionStatus CompanionStatus { get; set; }
        // 0x18
        public DataSkill CompanionSkill { get; set; }
        // 0x20
        public DataAbility CompanionAbility { get; set; }
        // 0x28
        public string Name { get; set; }
        // 0x30
        public int CompanionId { get; set; }
        // 0x34
        public int MaxLevel { get; set; }
        // 0x38
        public string Description { get; set; }
        // 0x40
        public int EnhancementCostNumericalFunctionId { get; set; }
        // 0x44
        public int CategoryType { get; set; }
        // 0x48
        public ActorAssetId ActorAssetId { get; set; }
        // 0x50
        public string UserCompanionUuid { get; set; }
        // 0x58
        public long AcquisitionDatetime { get; set; }
        // 0x60
        public StatusValue StatusValue { get; set; }
        // 0x7C
        public int Power { get; set; }

        public int Hp => StatusValue.Hp;
        public int Attack => StatusValue.Attack;
        public int Vitality => StatusValue.Vitality;
    }
}
