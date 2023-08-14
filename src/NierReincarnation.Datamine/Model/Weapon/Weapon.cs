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

        stringBuilder.AppendLine();

        return stringBuilder.ToString();
    }

    private void WriteWeaponInfo(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine($"__**Weapon: {Name} ({AttributeType.ToFormattedStr()} {WeaponType.ToFormattedStr()}) ({RarityType.ToFormattedStr(true)}) (lvl{Level}) ({ReleaseDateTimeOffset.ToFormattedDate()})**__");
    }

    private void WriteWeaponStats(StringBuilder stringBuilder)
    {
        if (Stats == null) return;

        stringBuilder.AppendLine($"**ATK:** {string.Join("/", Stats.Attack)}");
        stringBuilder.AppendLine($"**HP:** {string.Join("/", Stats.Hp)}");
        stringBuilder.AppendLine($"**DEF:** {string.Join("/", Stats.Defense)}");
    }

    private void WriteWeaponSkill(StringBuilder stringBuilder)
    {
        if (Skills == null) return;

        foreach (var skill in Skills.OrderBy(x => x.SlotNumber))
        {
            stringBuilder.AppendLine($"**Skill {skill.SlotNumber}:** {skill.Name} - {skill.Description} ({skill.Cooldown}sec)");
        }
    }

    private void WriteWeaponAbilities(StringBuilder stringBuilder)
    {
        if (Abilities == null) return;

        foreach (var ability in Abilities.OrderBy(x => x.SlotNumber))
        {
            stringBuilder.AppendLine($"**Ability {ability.SlotNumber}:** {ability.Name} - {ability.Description}");
        }
    }
}
