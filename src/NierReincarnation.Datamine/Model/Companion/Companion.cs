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

        return stringBuilder.ToString();
    }

    private void WriteCompanionInfo(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine($"Companion: {Name} ({AttributeType.ToFormattedStr()}) ({ReleaseDateTimeOffset.ToFormattedDate()})".ToHeader2());
    }

    private void WriteCompanionStats(StringBuilder stringBuilder)
    {
        if (Stats == null) return;

        stringBuilder.Append("ATK: ".ToBold()).Append(Stats.Attack).AppendLine();
        stringBuilder.Append("HP: ".ToBold()).Append(Stats.Hp).AppendLine();
        stringBuilder.Append("DEF: ".ToBold()).Append(Stats.Defense).AppendLine();
    }

    private void WriteCompanionSkill(StringBuilder stringBuilder)
    {
        if (Skill == null) return;

        stringBuilder.Append("Skill: ".ToBold()).Append(Skill.Name).Append(" - ").Append(Skill.Description).Append(" (").Append(Skill.Cooldown).AppendLine("sec)");
    }

    private void WriteCompanionAbility(StringBuilder stringBuilder)
    {
        if (Ability == null) return;

        stringBuilder.Append("Ability: ".ToBold()).Append(Ability.Name).Append(" - ").AppendLine(Ability.Description);
    }
}
