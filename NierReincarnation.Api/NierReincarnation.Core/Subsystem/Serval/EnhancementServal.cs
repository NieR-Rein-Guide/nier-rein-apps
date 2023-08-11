namespace NierReincarnation.Core.Subsystem.Serval;

public static class EnhancementServal
{
    public static int calcEnhancementExpByMaterial(int baseValue, bool isSameWeaponType, int weaponCoefficientPermil)
    {
        return isSameWeaponType ? baseValue * weaponCoefficientPermil / 1000 : baseValue;
    }

    // TODO: Figure out exp and coefficientPermil
    public static int calcEnhancementExpByWeapon(int baseValue, int exp, bool isSameWeaponType, int coefficientPermil, int weaponCoefficientPermil)
    {
        return isSameWeaponType ? baseValue * weaponCoefficientPermil / 1000 : baseValue;
    }
}
