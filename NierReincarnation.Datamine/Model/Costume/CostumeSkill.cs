namespace NierReincarnation.Datamine.Model;

public class CostumeSkill
{
    public string Name { get; init; }

    public string Description { get; init; }

    public string Gauge { get; init; }

    public int Cooldown { get; init; }

    public int CooldownMax => Cooldown * 80 / 100;
}
