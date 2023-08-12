using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Context.Models.Web;

public class GachaRateBasic
{
    public IList<RarityRateListElement> rarityRateList { get; set; }

    public IList<RarityRateListElement> lastChanceRarityRateList { get; set; }

    public IList<RarityRateDetail> rarityRateDetailList { get; set; }

    public IList<RarityRateDetail> lastChanceRarityRateDetailList { get; set; }

    public class RarityRateListElement
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
}
