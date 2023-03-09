using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class Companion
{
    public string Name { get; init; }

    public AttributeType AttributeType { get; init; }

    public DateTimeOffset ReleaseDateTimeOffset { get; init; }

    public CompanionStats Stats { get; init; }

    public CompanionSkill Skill { get; init; }

    public CompanionAbility Ability { get; init; }
}
