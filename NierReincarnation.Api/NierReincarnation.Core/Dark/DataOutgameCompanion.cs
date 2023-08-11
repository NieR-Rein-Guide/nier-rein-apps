using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark
{
    public class DataOutgameCompanion
    {
       
        public DataCompanionStatus CompanionStatus { get; set; }
       
        public DataSkill CompanionSkill { get; set; }
       
        public DataAbility CompanionAbility { get; set; }
       
        public string Name { get; set; }
       
        public int CompanionId { get; set; }
       
        public int MaxLevel { get; set; }
       
        public string Description { get; set; }
       
        public int EnhancementCostNumericalFunctionId { get; set; }
       
        public int CategoryType { get; set; }
       
        public ActorAssetId ActorAssetId { get; set; }
       
        public string UserCompanionUuid { get; set; }
       
        public long AcquisitionDatetime { get; set; }
       
        public StatusValue StatusValue { get; set; }
       
        public int Power { get; set; }

        public int Hp => StatusValue.Hp;
        public int Attack => StatusValue.Attack;
        public int Vitality => StatusValue.Vitality;
    }
}
