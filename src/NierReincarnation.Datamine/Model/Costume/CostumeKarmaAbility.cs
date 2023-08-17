namespace NierReincarnation.Datamine.Model;

public class CostumeKarmaAbility : CostumeKarmaItem
{
    public string Name { get; init; }

    public string Description { get; init; }

    public override string ToString() => !string.IsNullOrEmpty(Name) ? $"{Name} - " : "" + Description;
}
