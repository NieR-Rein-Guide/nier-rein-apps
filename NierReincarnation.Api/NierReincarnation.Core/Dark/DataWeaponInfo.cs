using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark;

public class DataWeaponInfo
{
    public string UserWeaponUuid { get; set; }
    public RarityType RarityType { get; set; }
    public AttributeType Attribute { get; set; }
    public WeaponType WeaponType { get; set; }
    public string Name { get; set; }
    public int WeaponId { get; set; }
    public int Level { get; set; }
    public ActorAssetId ActorAssetId { get; set; }
    public bool IsEndWeapon { get; set; }
}
