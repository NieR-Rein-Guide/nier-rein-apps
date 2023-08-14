namespace NierReincarnation.Core.Dark.Calculator.Database;

public static class CalculatorUserData
{
    public static EntityIUserDeck GetEntityIUserDeck(long userId, DeckType deckType, int userDeckNumber)
    {
        return DatabaseDefine.User.EntityIUserDeckTable
            .FindByUserIdAndDeckTypeAndUserDeckNumber((userId, deckType, userDeckNumber));
    }

    public static EntityIUserDeckCharacter GetEntityIUserDeckActor(long userId, string userDeckCharacterUuid)
    {
        return DatabaseDefine.User.EntityIUserDeckCharacterTable
            .FindByUserIdAndUserDeckCharacterUuid((userId, userDeckCharacterUuid));
    }

    public static EntityIUserCostume GetEntityIUserBattleActorCostume(long userId, string userCostumeUuid)
    {
        return DatabaseDefine.User.EntityIUserCostumeTable
            .FindByUserIdAndUserCostumeUuid((userId, userCostumeUuid));
    }

    public static EntityIUserCostumeActiveSkill GetEntityIUserCostumeActiveSkill(long userId, string userCostumeUuid)
    {
        return DatabaseDefine.User.EntityIUserCostumeActiveSkillTable
            .FindByUserIdAndUserCostumeUuid((userId, userCostumeUuid));
    }

    public static EntityIUserWeapon GetEntityIUserWeapon(long userId, string userWeaponUuid)
    {
        return DatabaseDefine.User.EntityIUserWeaponTable
            .FindByUserIdAndUserWeaponUuid((userId, userWeaponUuid));
    }

    public static List<EntityIUserWeapon> GetEntityIUserWeaponListDeckSubWeapon(long userId, string userWeaponUuid)
    {
        return DatabaseDefine.User.EntityIUserWeaponTable.All
            .Where(x => x.UserId == userId && x.UserWeaponUuid == userWeaponUuid)
            .ToList();
    }

    public static EntityIUserCompanion GetEntityIUserBattleActorCompanion(long userId, string userCompanionUuid)
    {
        return DatabaseDefine.User.EntityIUserCompanionTable
            .FindByUserIdAndUserCompanionUuid((userId, userCompanionUuid));
    }

    public static List<EntityIUserParts> GetEntityIUserPartsListDeckParts(long userId, string userDeckCharacterUuid)
    {
        return DatabaseDefine.User.EntityIUserDeckPartsGroupTable.All
            .Where(x => x.UserId == userId && x.UserDeckCharacterUuid == userDeckCharacterUuid)
            .Select(x => DatabaseDefine.User.EntityIUserPartsTable.FindByUserIdAndUserPartsUuid((userId, x.UserPartsUuid)))
            .ToList();
    }

    public static List<EntityIUserPartsStatusSub> GetEntityIUserPartsStatusSubList(long userId, string userPartsUuid)
    {
        return DatabaseDefine.User.EntityIUserPartsStatusSubTable.All
            .Where(x => x.UserId == userId && x.UserPartsUuid == userPartsUuid)
            .ToList();
    }

    public static List<EntityIUserWeaponSkill> GetEntityIUserWeaponSkillList(long userId, string userWeaponUuid)
    {
        return DatabaseDefine.User.EntityIUserWeaponSkillTable.All
            .Where(x => x.UserId == userId && x.UserWeaponUuid == userWeaponUuid)
            .ToList();
    }

    public static List<EntityIUserWeaponAbility> GetEntityIUserWeaponAbilityList(long userId, string userWeaponUuid)
    {
        return DatabaseDefine.User.EntityIUserWeaponAbilityTable.All
            .Where(x => x.UserId == userId && x.UserWeaponUuid == userWeaponUuid)
            .ToList();
    }

    public static List<EntityIUserBigHuntWeeklyStatus> GetEntityIUserBigHuntWeeklyStatusList(long userId)
    {
        return DatabaseDefine.User.EntityIUserBigHuntWeeklyStatusTable.All
            .Where(x => x.UserId == userId)
            .ToList();
    }

    public static List<EntityIUserPvpWeeklyResult> GetEntityIUserPvpWeeklyResultList(long userId)
    {
        return DatabaseDefine.User.EntityIUserPvpWeeklyResultTable.All
            .Where(x => x.UserId == userId)
            .ToList();
    }
}
