using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Context.Models.Web;

public class GachaRateStepup
{
    public int currentStepNumber { get; set; }

    public int maxStepNumber { get; set; }

    public IList<StepupRateDetail> stepupRateDetailList { get; set; }

    public class StepupRateDetail
    {
        public int stepNumber { get; set; }

        public IList<RarityRate> rarityRateList { get; set; }

        public IList<RarityRate> lastChanceRarityRateList { get; set; }

        public IList<RarityRateDetail> rarityRateDetailList { get; set; }

        public IList<RarityRateDetail> lastChanceRarityRateDetailList { get; set; }

        public IList<DuplicationBonusRate> duplicationBonusRateList { get; set; }
    }

    public class RarityRate
    {
        public RarityType rarityType { get; set; }

        public string rateString { get; set; }

        public bool withCostume { get; set; }
    }

    public class RarityRateDetail
    {
        public GachaOddsItem gachaOddsItem { get; set; }

        public string rateString { get; set; }

        public class GachaOddsItem
        {
            public GachaItem gachaItem { get; set; }

            public IList<ReleaseItem> releaseItem { get; set; }

            public class GachaItem
            {
                public RarityType rarityType { get; set; }

                public PossessionType possessionType { get; set; }

                public AttributeType attributeType { get; set; }

                public WeaponType weaponType { get; set; }

                public int possessionId { get; set; }

                public int count { get; set; }

                public string name { get; set; }

                public bool isPickup { get; set; }
            }

            public class ReleaseItem
            {
                public RarityType rarityType { get; set; }

                public PossessionType possessionType { get; set; }

                public int possessionId { get; set; }

                public int count { get; set; }

                public string costumeName { get; set; }

                public string characterName { get; set; }
            }
        }
    }

    public class DuplicationBonusRate
    {
        public RarityType rarityType { get; set; }

        public IList<DuplicationBonusGradeRate> duplicationBonusGradeRateList { get; set; }

        public class DuplicationBonusGradeRate
        {
            public int grade { get; set; }

            public int amount { get; set; }

            public string rateString { get; set; }
        }
    }
}
