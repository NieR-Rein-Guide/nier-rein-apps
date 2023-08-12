using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark;

public class DataOutgameCostumeInfo
{
    public string UserCostumeUuid { get; set; }

    public int CharacterId { get; set; }

    public int CostumeId { get; set; }

    public WeaponType WeaponType { get; set; }

    public RarityType RarityType { get; set; }

    public int Level { get; set; }

    public ActorAssetId ActorAssetId { get; set; }

    public int AwakenCount { get; set; }
}
