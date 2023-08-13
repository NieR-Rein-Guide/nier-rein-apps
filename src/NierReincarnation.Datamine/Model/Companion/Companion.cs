using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class Companion
{
    public string Name { get; init; }

    public AttributeType AttributeType { get; init; }

    public DateTimeOffset ReleaseDateTimeOffset { get; init; }

    public CompanionStats Stats { get; init; }

    public CompanionSkill Skill { get; init; }

    public CompanionAbility Ability { get; init; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        // Companion
        WriteCompanionInfo(stringBuilder);

        // Stats
        WriteCompanionStats(stringBuilder);

        // Skill
        WriteCompanionSkill(stringBuilder);

        // Ability
        WriteCompanionAbility(stringBuilder);

        stringBuilder.AppendLine();

        return stringBuilder.ToString();
    }

    private void WriteCompanionInfo(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine($"__**Companion: {Name} ({AttributeType.ToFormattedStr()}) ({ReleaseDateTimeOffset.ToFormattedDate()})**__");
    }

    private void WriteCompanionStats(StringBuilder stringBuilder)
    {
        if (Stats == null) return;

        stringBuilder.AppendLine($"**ATK:** {Stats.Attack}");
        stringBuilder.AppendLine($"**HP:** {Stats.Hp}");
        stringBuilder.AppendLine($"**DEF:** {Stats.Defense}");
    }

    private void WriteCompanionSkill(StringBuilder stringBuilder)
    {
        if (Skill == null) return;

        stringBuilder.AppendLine($"**Skill:** {Skill.Name} - {Skill.Description} ({Skill.Cooldown}sec)");
    }

    private void WriteCompanionAbility(StringBuilder stringBuilder)
    {
        if (Ability == null) return;

        stringBuilder.AppendLine($"**Ability:** {Ability.Name} - {Ability.Description}");
    }
}
