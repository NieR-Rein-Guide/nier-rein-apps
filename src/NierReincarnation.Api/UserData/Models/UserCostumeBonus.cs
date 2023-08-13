namespace NierReincarnation.UserData.Models;

public class UserCostumeBonus
{
    public int characterId { get; set; }

    public StatusCalculationType statusCalculationType { get; set; }

    public int hp { get; set; }

    public int attack { get; set; }

    public int vitality { get; set; }

    public int agility { get; set; }

    public int criticalRatio { get; set; }

    public int criticalAttack { get; set; }
}
