namespace NierReincarnation.Core.Dark.Status
{
    public struct StatusValue
    {
        // 0x0
        public int Agility { get; set; }

        // 0x4
        public int Attack { get; set; }

        // 0x8
        public int CriticalAttack { get; set; }

        // 0xC
        public int CriticalRatio { get; set; }

        // 0x10
        public int EvasionRatio { get; set; }

        // 0x14
        public int Hp { get; set; }

        // 0x18
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
}
