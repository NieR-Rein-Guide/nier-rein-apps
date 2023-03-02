using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class Costume
{
    public string Name { get; init; }

    public string AssetId { get; init; }

    public int Level { get; init; }

    public WeaponType WeaponType { get; init; }

    public RarityType RarityType { get; init; }

    public DateTimeOffset ReleaseDateTimeOffset { get; init; }

    public List<CostumeStats> Stats { get; init; }

    public CostumeSkill Skill { get; init; }

    public List<CostumeAbility> Abilities { get; init; }

    public Debris Debris { get; init; }

    public IEnumerable<string> AwakenStrings => Stats?.OrderBy(x => x.Awakenings).Select(x => x.Awakenings != null ? $"A{x.Awakenings}" : "Base").Distinct();

    public IEnumerable<int> AgilityStrings => Stats?.OrderBy(x => x.Awakenings).Select(x => x.Agility);

    public IEnumerable<int> AttackStrings => Stats?.OrderBy(x => x.Awakenings).Select(x => x.Attack);

    public IEnumerable<int> HpStrings => Stats?.OrderBy(x => x.Awakenings).Select(x => x.Hp);

    public IEnumerable<int> DefenseStrings => Stats?.OrderBy(x => x.Awakenings).Select(x => x.Defense);

    public IEnumerable<string> CritRateStrings => Stats?.OrderBy(x => x.Awakenings).Select(x => $"{x.CritRate}%");

    public IEnumerable<string> CritDamageStrings => Stats?.OrderBy(x => x.Awakenings).Select(x => $"{x.CritDamage}%");

    public IEnumerable<string> EvasionRateStrings => Stats?.OrderBy(x => x.Awakenings).Select(x => $"{x.EvasionRate}%");
}
