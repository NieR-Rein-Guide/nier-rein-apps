namespace NierReincarnation.Core.Subsystem.Serval
{
    public static class PowerServal
    {
        public static int calcWeaponStatusPower(int statusValue, int coefficientPermil)
        {
            return coefficientPermil * statusValue / 1000;
        }

        public static int calcStatusPower(int statusValue, int coefficientPermil)
        {
            return coefficientPermil * statusValue / 1000;
        }

        public static int calcStatusPower(int agility, int attack, int criticalAttack, int criticalRatio, int evasionRatio,
            int hp, int vitality, int agilityCoefficientPermil, int attackCoefficientPermil, int criticalAttackCoefficientPermil,
            int criticalRatioCoefficientPermil, int evasionRatioCoefficientPermil, int hpCoefficientPermil, int vitalityCoefficientPermil)
        {
            return (agility * agilityCoefficientPermil / 1000) +
                   (attack * attackCoefficientPermil / 1000) +
                   (criticalAttack * criticalAttackCoefficientPermil / 1000) +
                   (criticalRatio * criticalRatioCoefficientPermil / 1000) +
                   (evasionRatio * evasionRatioCoefficientPermil / 1000) +
                   (hp * hpCoefficientPermil / 1000) +
                   (vitality * vitalityCoefficientPermil / 1000);
        }

        public static int calcStatusReferenceValue(int statusValue, int coefficientPermil)
        {
            return coefficientPermil * statusValue / 1000;
        }

        public static int calcSkillPower(int skillPowerBaseValue, int statusReferenceValue)
        {
            return statusReferenceValue + skillPowerBaseValue;
        }
    }
}
