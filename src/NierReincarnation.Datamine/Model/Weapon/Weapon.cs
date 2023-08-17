using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;
using System.Text;

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

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        // Weapon
        WriteWeaponInfo(stringBuilder);

        // Stats
        WriteWeaponStats(stringBuilder);

        // Skills
        WriteWeaponSkill(stringBuilder);

        // Abilities
        WriteWeaponAbilities(stringBuilder);

        return stringBuilder.ToString();
    }

    private void WriteWeaponInfo(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine($"Weapon: {Name} ({AttributeType.ToFormattedStr()} {WeaponType.ToFormattedStr()}) ({RarityType.ToFormattedStr(true)}) (lvl{Level}) ({ReleaseDateTimeOffset.ToFormattedDate()})".ToHeader2());
    }

    private void WriteWeaponStats(StringBuilder stringBuilder)
    {
        if (Stats == null) return;

        stringBuilder.Append("ATK: ".ToBold()).AppendJoin("/", Stats.Attack).AppendLine();
        stringBuilder.Append("HP: ".ToBold()).AppendJoin("/", Stats.Hp).AppendLine();
        stringBuilder.Append("DEF: ".ToBold()).AppendJoin("/", Stats.Defense).AppendLine();
    }

    private void WriteWeaponSkill(StringBuilder stringBuilder)
    {
        if (Skills == null) return;

        foreach (var skill in Skills.OrderBy(x => x.SlotNumber))
        {
            stringBuilder.Append($"Skill {skill.SlotNumber}: ".ToBold()).Append(skill.Name).Append(" - ").Append(skill.Description).Append(" (").Append(skill.Cooldown).AppendLine("sec)");
        }
    }

    private void WriteWeaponAbilities(StringBuilder stringBuilder)
    {
        if (Abilities == null) return;

        foreach (var ability in Abilities.OrderBy(x => x.SlotNumber))
        {
            stringBuilder.Append($"Ability {ability.SlotNumber}: ".ToBold()).Append(ability.Name).Append(" - ").AppendLine(ability.Description);
        }
    }
}
