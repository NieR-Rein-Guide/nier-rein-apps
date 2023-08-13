namespace NierReincarnation.Datamine.Model;

public class WeaponSkill
{
    public string Name { get; init; }

    public string Description { get; init; }

    public int SlotNumber { get; init; }

    public int Cooldown { get; init; }

    public int CooldownMax => Cooldown * 80 / 100;
}
