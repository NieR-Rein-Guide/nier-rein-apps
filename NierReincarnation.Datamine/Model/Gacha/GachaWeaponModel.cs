using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class GachaWeaponModel
{
    public string Name { get; init; }

    public RarityType RarityType { get; init; }

    public AttributeType AttributeType { get; init; }

    public WeaponType WeaponType { get; init; }

    public string FileName { get; init; }
}
