using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class Weapon
{
    public string Name { get; init; }

    public string AssetId { get; init; }

    public int Level { get; init; }

    public RarityType RarityType { get; init; }

    public AttributeType AttributeType { get; init; }

    public WeaponType WeaponType { get; init; }

    public DateTimeOffset ReleaseDateTimeOffset { get; init; }

    public WeaponStats Stats { get; init; }

    public List<WeaponSkill> Skills { get; init; }

    public List<WeaponAbility> Abilities { get; init; }

    public bool CanBeRefined => Abilities.Any(x => x.SourceType == AbilitySourceType.AWAKEN);
}
