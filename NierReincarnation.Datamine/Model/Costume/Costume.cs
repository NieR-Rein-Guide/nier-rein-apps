using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;
using System.Text;
using static NierReincarnation.Core.Dark.View.UserInterface.Text.UserInterfaceTextKey;

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

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        // Costume
        WriteCostumeInfo(stringBuilder);

        // Stats
        WriteCostumeStats(stringBuilder);

        // Skill
        WriteCostumeSkill(stringBuilder);

        // Abilities
        WriteCostumeAbilities(stringBuilder);

        // Debris
        WriteCostumeDebris(stringBuilder);

        stringBuilder.AppendLine();

        return stringBuilder.ToString();
    }

    private void WriteCostumeInfo(StringBuilder stringBuilder)
    {
        var awakenings = string.Join("/", AwakenStrings);
        stringBuilder.AppendLine($"__**Costume: {Name} ({WeaponType.ToFormattedStr()}) ({RarityType.ToFormattedStr(false)}) (lvl{Level}) ({awakenings}) ({ReleaseDateTimeOffset.ToFormattedDate()})**__");
    }

    private void WriteCostumeStats(StringBuilder stringBuilder)
    {
        if (Stats == null) return;

        var baseStats = Stats.Find(x => x.Awakenings == null);
        stringBuilder.AppendLine($"**ATK:** {string.Join("/", AttackStrings)}");
        stringBuilder.AppendLine($"**HP:** {string.Join("/", HpStrings)}");
        stringBuilder.AppendLine($"**DEF:** {string.Join("/", DefenseStrings)}");

        if (baseStats.Agility != 1000)
        {
            stringBuilder.AppendLine($"**AGI:** {string.Join("/", AgilityStrings)}");
        }

        if (baseStats.CritRate != 10)
        {
            stringBuilder.AppendLine($"**CR:** {string.Join("/", CritRateStrings)}");
        }

        if (baseStats.CritDamage != 150)
        {
            stringBuilder.AppendLine($"**CD:** {string.Join("/", CritDamageStrings)}");
        }

        if (baseStats.EvasionRate != 10)
        {
            stringBuilder.AppendLine($"**EV:** {string.Join("/", EvasionRateStrings)}");
        }
    }

    private void WriteCostumeSkill(StringBuilder stringBuilder)
    {
        if (Skill == null) return;
        stringBuilder.AppendLine($"**Skill:** {Skill.Name} - {Skill.Description} - {Skill.Gauge} Gauge ({Skill.Cooldown}/{Skill.CooldownMax})");
    }

    private void WriteCostumeAbilities(StringBuilder stringBuilder)
    {
        if (Abilities == null) return;
        foreach (var ability in Abilities)
        {
            stringBuilder.AppendLine($"**Ability {ability.SlotNumber}:** {ability.Name} - {ability.Description}");
        }
    }

    private void WriteCostumeDebris(StringBuilder stringBuilder)
    {
        if (Debris != null)
        {
            stringBuilder.AppendLine($"**Debris:** {Debris.Name} - {Debris.Description}");
        }
    }
}
