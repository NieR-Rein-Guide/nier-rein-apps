using System.Text;

namespace NierReincarnation.Datamine.Model;

public class CostumeKarmaStats : CostumeKarmaItem
{
    public decimal AgilityFlat { get; set; }

    public decimal AgilityPercent { get; set; }

    public decimal AttackFlat { get; set; }

    public decimal AttackPercent { get; set; }

    public decimal HpFlat { get; set; }

    public decimal HpPercent { get; set; }

    public decimal DefenseFlat { get; set; }

    public decimal DefensePercent { get; set; }

    public decimal EvasionRate { get; set; }

    public decimal CriticalDamage { get; set; }

    public decimal CriticalRate { get; set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        List<string> stats = [];

        if (AgilityFlat != 0)
        {
            stats.Add($"Agility +{AgilityFlat}");
        }
        if (AgilityPercent != 0)
        {
            stats.Add($"Agility +{AgilityPercent / 10}%");
        }
        if (AttackFlat != 0)
        {
            stats.Add($"Attack +{AttackFlat}");
        }
        if (AttackPercent != 0)
        {
            stats.Add($"Attack +{AttackPercent / 10}%");
        }
        if (HpFlat != 0)
        {
            stats.Add($"HP +{HpFlat}");
        }
        if (HpPercent != 0)
        {
            stats.Add($"HP +{HpPercent / 10}%");
        }
        if (DefenseFlat != 0)
        {
            stats.Add($"Defense +{DefenseFlat}");
        }
        if (DefensePercent != 0)
        {
            stats.Add($"Defense +{DefensePercent / 10}%");
        }
        if (EvasionRate != 0)
        {
            stats.Add($"Evasion +{EvasionRate / 10}%");
        }
        if (CriticalDamage != 0)
        {
            stats.Add($"Crit Damage +{CriticalDamage / 10}%");
        }
        if (CriticalRate != 0)
        {
            stats.Add($"Crit Rate +{CriticalRate / 10}%");
        }

        stringBuilder.AppendJoin(", ", stats);

        return stringBuilder.ToString();
    }
}
