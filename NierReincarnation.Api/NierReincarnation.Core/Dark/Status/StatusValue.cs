namespace NierReincarnation.Core.Dark.Status;

public struct StatusValue
{
   
    public int Agility { get; set; }

   
    public int Attack { get; set; }

   
    public int CriticalAttack { get; set; }

   
    public int CriticalRatio { get; set; }

   
    public int EvasionRatio { get; set; }

   
    public int Hp { get; set; }

   
    public int Vitality { get; set; }

    public StatusValue(int agility, int attack, int criticalAttack, int criticalRatio, int evasionRatio, int hp, int vitality)
    {
        Agility = agility;
        Attack = attack;
        CriticalAttack = criticalAttack;
        CriticalRatio = criticalRatio;
        EvasionRatio = evasionRatio;
        Hp = hp;
        Vitality = vitality;
    }

    public static StatusValue operator +(StatusValue a, StatusValue b)
    {
        return new StatusValue(
            a.Agility + b.Agility,
            a.Attack + b.Attack,
            a.CriticalAttack + b.CriticalAttack,
            a.CriticalRatio + b.CriticalRatio,
            a.EvasionRatio + b.EvasionRatio,
            a.Hp + b.Hp,
            a.Vitality + b.Vitality);
    }
}
