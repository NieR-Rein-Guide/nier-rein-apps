using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;
using System.Text;

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

    public List<CostumeKarmaSlot> KarmaSlots { get; init; }

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

        // Karma slots
        WriteCostumeKarmaSlots(stringBuilder);

        return stringBuilder.ToString();
    }

    private void WriteCostumeInfo(StringBuilder stringBuilder)
    {
        var awakenings = string.Join("/", AwakenStrings);
        stringBuilder.AppendLine($"Costume: {Name} ({WeaponType.ToFormattedStr()}) ({RarityType.ToFormattedStr(false)}) (lvl{Level}) ({awakenings}) ({ReleaseDateTimeOffset.ToFormattedDate()})".ToHeader2());
    }

    private void WriteCostumeStats(StringBuilder stringBuilder)
    {
        if (Stats == null) return;

        var baseStats = Stats.Find(x => x.Awakenings == null);
        stringBuilder.Append("ATK: ".ToBold()).AppendJoin("/", AttackStrings).AppendLine();
        stringBuilder.Append("HP: ".ToBold()).AppendJoin("/", HpStrings).AppendLine();
        stringBuilder.Append("DEF: ".ToBold()).AppendJoin("/", DefenseStrings).AppendLine();

        if (baseStats.Agility != 1000)
        {
            stringBuilder.Append("AGI: ".ToBold()).AppendJoin("/", AgilityStrings).AppendLine();
        }

        if (baseStats.CritRate != 10)
        {
            stringBuilder.Append("CR: ".ToBold()).AppendJoin("/", CritRateStrings).AppendLine();
        }

        if (baseStats.CritDamage != 150)
        {
            stringBuilder.Append("CD: ".ToBold()).AppendJoin("/", CritDamageStrings).AppendLine();
        }

        if (baseStats.EvasionRate != 10)
        {
            stringBuilder.Append("EV: ".ToBold()).AppendJoin("/", EvasionRateStrings).AppendLine();
        }
    }

    private void WriteCostumeSkill(StringBuilder stringBuilder)
    {
        if (Skill == null) return;
        stringBuilder.Append("Skill: ".ToBold()).Append(Skill.Name).Append(" - ").Append(Skill.Description).Append(" - ").Append(Skill.Gauge).Append(" Gauge (").Append(Skill.Cooldown).Append('/').Append(Skill.CooldownMax).AppendLine(")");
    }

    private void WriteCostumeAbilities(StringBuilder stringBuilder)
    {
        if (Abilities == null) return;
        foreach (var ability in Abilities)
        {
            stringBuilder.Append($"Ability {ability.SlotNumber}: ".ToBold()).Append(ability.Name).Append(" - ").AppendLine(ability.Description);
        }
    }

    private void WriteCostumeDebris(StringBuilder stringBuilder)
    {
        if (Debris != null)
        {
            stringBuilder.AppendLine(Debris.ToString());
        }
    }

    private void WriteCostumeKarmaSlots(StringBuilder stringBuilder)
    {
        if (KarmaSlots?.Count > 0)
        {
            stringBuilder.AppendLine($"Karma Slots ({RarityType.SS_RARE.ToFormattedStr(false)})".ToBold());
            foreach (var karmaSlot in KarmaSlots)
            {
                stringBuilder.Append(karmaSlot.ToString());
            }
        }
    }
}
