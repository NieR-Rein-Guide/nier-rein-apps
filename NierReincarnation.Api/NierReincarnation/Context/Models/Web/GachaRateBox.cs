namespace NierReincarnation.Context.Models.Web;

public class GachaRateBox
{
    public int boxLevel { get; set; }

    public IList<BoxRateDetail> boxRateDetailList { get; set; }

    public class BoxRateDetail
    {
        public GachaOddsItem gachaOddsItem { get; set; }

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
