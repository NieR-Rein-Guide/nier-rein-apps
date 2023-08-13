using NierReincarnation.Core.Dark.Calculator.Database;

namespace NierReincarnation.Core.Dark.Calculator.Factory;

public static class CalculatorQuestSetupBattleWithNpcUserEntity
{
    public static bool IsValidUuid(string uuid)
    {
        return !string.IsNullOrEmpty(uuid);
    }

    public static EntityIUserDeck CreateEntityIUserDeck(long userId, DeckType deckType, int userDeckNumber, bool fromNpcTable)
    {
        return fromNpcTable
            ? GetEntityIUserDeckFromNpcTable(userId, deckType, userDeckNumber)
            : CalculatorUserData.GetEntityIUserDeck(userId, deckType, userDeckNumber);
    }

    public static EntityIUserDeckCharacter CreateEntityIUserDeckCharacter(long userId, string userDeckCharacterUuid, bool fromNpcTable)
    {
        return fromNpcTable
            ? GetEntityIUserDeckActorFromNpcTable(userId, userDeckCharacterUuid)
            : CalculatorUserData.GetEntityIUserDeckActor(userId, userDeckCharacterUuid);
    }

    public static EntityIUserCostume CreateEntityIUserCostume(long userId, string userCostumeUuid, bool fromNpcTable)
    {
        return fromNpcTable
            ? GetEntityIUserCostumeFromNpcTable(npcId: userId, npcCostumeUuid: userCostumeUuid)
            : CalculatorUserData.GetEntityIUserBattleActorCostume(userId: userId, userCostumeUuid: userCostumeUuid);
    }

    public static EntityIUserCharacter CreateEntityIUserCharacter(long userId, int characterId, bool fromNpcTable)
    {
        return fromNpcTable
            ? DatabaseDefine.User.EntityIUserCharacterTable.FindByUserIdAndCharacterId((userId, characterId))
            : GetEntityIUserCharacterFromNpcTable(userId, characterId);
    }

    public static EntityIUserCostumeActiveSkill CreateEntityIUserCostumeActiveSkill(long userId, string userCostumeUuid, bool fromNpcTable)
    {
        return fromNpcTable
            ? GetEntityIUserCostumeActiveSkillFromNpcTable(userId, userCostumeUuid)
            : CalculatorUserData.GetEntityIUserCostumeActiveSkill(userId, userCostumeUuid);
    }

    public static EntityIUserWeapon CreateEntityIUserWeapon(long userId, string userWeaponUuid, bool fromNpcTable)
    {
        return fromNpcTable
            ? GetEntityIUserWeaponFromNpcTable(userId, userWeaponUuid)
            : CalculatorUserData.GetEntityIUserWeapon(userId, userWeaponUuid);
    }

    //public static List<EntityIUserWeapon> CreateEntityIUserDeckSubWeaponList(long userId, string userDeckCharacterUuid, bool fromNpcTable)
    //{
    //}

    public static EntityIUserCompanion CreateEntityIUserBattleActorCompanion(long userId, string userCompanionUuid, bool fromNpcTable)
    {
        return fromNpcTable
            ? GetEntityIUserBattleActorCompanionFromNpcTable(userId, userCompanionUuid)
            : CalculatorUserData.GetEntityIUserBattleActorCompanion(userId, userCompanionUuid);
    }

    //public static List<EntityIUserParts> CreateEntityIUserPartsDeckPartsList(long userId, string userDeckPartsGroupUuid, bool fromNpcTable)
    //{
    //    return fromNpcTable
    //        ? GetEntityIUserPartsListDeckPartsFromNpcTable(userId, userDeckPartsGroupUuid)
    //        : CalculatorUserData.GetEntityIUserPartsListDeckParts(userId, userDeckPartsGroupUuid);
    //}

    public static List<EntityIUserPartsStatusSub> CreateEntityIuserPartsStatusSubList(long userId, string userPartsUuid, bool fromNpcTable)
    {
        return fromNpcTable
            ? GetEntityIUserPartsStatusSubListFromNpcTable(userId, userPartsUuid)
            : CalculatorUserData.GetEntityIUserPartsStatusSubList(userId, userPartsUuid);
    }

    public static List<EntityIUserWeaponSkill> CreateEntityIUserWeaponSkillList(long userId, string userWeaponUuid, bool fromNpcTable)
    {
        return fromNpcTable
            ? GetEntityIUserWeaponSkillListFromNpcTable(userId, userWeaponUuid)
            : CalculatorUserData.GetEntityIUserWeaponSkillList(userId, userWeaponUuid);
    }

    public static List<EntityIUserWeaponAbility> CreateEntityIUserWeaponAbilityList(long userId, string userWeaponUuid, bool fromNpcTable)
    {
        return fromNpcTable
            ? GetEntityIUserWeaponAbilityListFromNpcTable(userId, userWeaponUuid)
            : CalculatorUserData.GetEntityIUserWeaponAbilityList(userId, userWeaponUuid);
    }

    private static EntityIUserDeck GetEntityIUserDeckFromNpcTable(long npcId, DeckType deckType, int npcDeckNumber)
    {
        var entityMBattleNpcDeck = DatabaseDefine.Master.EntityMBattleNpcDeckTable
            .FindByBattleNpcIdAndDeckTypeAndBattleNpcDeckNumber((npcId, deckType, npcDeckNumber));

        return new EntityIUserDeck(entityMBattleNpcDeck.BattleNpcId, entityMBattleNpcDeck.DeckType, entityMBattleNpcDeck.BattleNpcDeckNumber,
            entityMBattleNpcDeck.BattleNpcDeckCharacterUuid01, entityMBattleNpcDeck.BattleNpcDeckCharacterUuid02, entityMBattleNpcDeck.BattleNpcDeckCharacterUuid03,
            entityMBattleNpcDeck.Name, entityMBattleNpcDeck.Power, 1);
    }

    private static EntityIUserDeckCharacter GetEntityIUserDeckActorFromNpcTable(long npcId, string npcDeckCharacterUuid)
    {
        var entityMBattleNpcDeckCharacter = DatabaseDefine.Master.EntityMBattleNpcDeckCharacterTable
            .FindByBattleNpcIdAndBattleNpcDeckCharacterUuid((npcId, npcDeckCharacterUuid));

        return new EntityIUserDeckCharacter()
        {
            MainUserWeaponUuid = entityMBattleNpcDeckCharacter.MainBattleNpcWeaponUuid,
            Power = entityMBattleNpcDeckCharacter.Power,
            UserCompanionUuid = entityMBattleNpcDeckCharacter.BattleNpcCompanionUuid,
            UserCostumeUuid = entityMBattleNpcDeckCharacter.BattleNpcCostumeUuid,
            UserDeckCharacterUuid = entityMBattleNpcDeckCharacter.BattleNpcDeckCharacterUuid,
            UserId = entityMBattleNpcDeckCharacter.BattleNpcId,
            UserThoughtUuid = entityMBattleNpcDeckCharacter.BattleNpcThoughtUuid,
            LatestVersion = 1
        };
    }

    private static EntityIUserCostume GetEntityIUserCostumeFromNpcTable(long npcId, string npcCostumeUuid)
    {
        var entityMBattleNpcCostume = DatabaseDefine.Master.EntityMBattleNpcCostumeTable
            .FindByBattleNpcIdAndBattleNpcCostumeUuid((npcId, npcCostumeUuid));

        return new EntityIUserCostume()
        {
            AcquisitionDatetime = entityMBattleNpcCostume.AcquisitionDatetime,
            AwakenCount = entityMBattleNpcCostume.AwakenCount,
            CostumeId = entityMBattleNpcCostume.CostumeId,
            Exp = entityMBattleNpcCostume.Exp,
            HeadupDisplayViewId = entityMBattleNpcCostume.HeadupDisplayViewId,
            LatestVersion = 1,
            Level = entityMBattleNpcCostume.Level,
            LimitBreakCount = entityMBattleNpcCostume.LimitBreakCount,
            UserCostumeUuid = entityMBattleNpcCostume.BattleNpcCostumeUuid,
            UserId = entityMBattleNpcCostume.BattleNpcId
        };
    }

    private static EntityIUserCharacter GetEntityIUserCharacterFromNpcTable(long npcId, int characterId)
    {
        var entityMBattleNpcCharacter = DatabaseDefine.Master.EntityMBattleNpcCharacterTable
            .FindByBattleNpcIdAndCharacterId((npcId, characterId));

        if (entityMBattleNpcCharacter is null) return default!;

        return new EntityIUserCharacter()
        {
            CharacterId = entityMBattleNpcCharacter.CharacterId,
            Exp = entityMBattleNpcCharacter.Exp,
            Level = entityMBattleNpcCharacter.Level,
            UserId = entityMBattleNpcCharacter.BattleNpcId
        };
    }

    private static EntityIUserCostumeActiveSkill GetEntityIUserCostumeActiveSkillFromNpcTable(long npcId, string npcCostumeUuid)
    {
        var entityMBattleNpcCostumeActiveSkill = DatabaseDefine.Master.EntityMBattleNpcCostumeActiveSkillTable
            .FindByBattleNpcIdAndBattleNpcCostumeUuid((npcId, npcCostumeUuid));

        if (entityMBattleNpcCostumeActiveSkill is null) return default!;

        return new EntityIUserCostumeActiveSkill()
        {
            AcquisitionDatetime = entityMBattleNpcCostumeActiveSkill.AcquisitionDatetime,
            LatestVersion = 1,
            Level = entityMBattleNpcCostumeActiveSkill.Level,
            UserCostumeUuid = entityMBattleNpcCostumeActiveSkill.BattleNpcCostumeUuid,
            UserId = entityMBattleNpcCostumeActiveSkill.BattleNpcId
        };
    }

    private static EntityIUserWeapon GetEntityIUserWeaponFromNpcTable(long npcId, string npcWeaponUuid)
    {
        var entityMBattleNpcWeapon = DatabaseDefine.Master.EntityMBattleNpcWeaponTable
            .FindByBattleNpcIdAndBattleNpcWeaponUuid((npcId, npcWeaponUuid));

        return new EntityIUserWeapon()
        {
            AcquisitionDatetime = entityMBattleNpcWeapon.AcquisitionDatetime,
            Exp = entityMBattleNpcWeapon.Exp,
            IsProtected = entityMBattleNpcWeapon.IsProtected,
            LatestVersion = 1,
            Level = entityMBattleNpcWeapon.Level,
            LimitBreakCount = entityMBattleNpcWeapon.LimitBreakCount,
            UserId = entityMBattleNpcWeapon.BattleNpcId,
            UserWeaponUuid = entityMBattleNpcWeapon.BattleNpcWeaponUuid,
            WeaponId = entityMBattleNpcWeapon.WeaponId
        };
    }

    private static EntityIUserCompanion GetEntityIUserBattleActorCompanionFromNpcTable(long npcId, string npcCompanionUuid)
    {
        var entityMBattleNpcCompanion = DatabaseDefine.Master.EntityMBattleNpcCompanionTable
            .FindByBattleNpcIdAndBattleNpcCompanionUuid((npcId, npcCompanionUuid));

        return new EntityIUserCompanion()
        {
            AcquisitionDatetime = entityMBattleNpcCompanion.AcquisitionDatetime,
            CompanionId = entityMBattleNpcCompanion.CompanionId,
            HeadupDisplayViewId = entityMBattleNpcCompanion.HeadupDisplayViewId,
            LatestVersion = 1,
            Level = entityMBattleNpcCompanion.Level,
            UserCompanionUuid = entityMBattleNpcCompanion.BattleNpcCompanionUuid,
            UserId = entityMBattleNpcCompanion.BattleNpcId
        };
    }

    //private static List<EntityIUserParts> GetEntityIUserPartsListDeckPartsFromNpcTable(long npcId, string npcDeckCharacterUuid)
    //{
    //}

    private static List<EntityIUserPartsStatusSub> GetEntityIUserPartsStatusSubListFromNpcTable(long npcId, string npcPartsUuid)
    {
        return DatabaseDefine.Master.EntityMBattleNpcPartsStatusSubTable.All
            .Where(x => x.BattleNpcId == npcId && x.BattleNpcPartsUuid == npcPartsUuid)
            .Select(x => new EntityIUserPartsStatusSub()
            {
                LatestVersion = 1,
                Level = x.Level,
                PartsStatusSubLotteryId = x.PartsStatusSubLotteryId,
                StatusCalculationType = x.StatusCalculationType,
                StatusChangeValue = x.StatusChangeValue,
                StatusIndex = x.StatusIndex,
                StatusKindType = x.StatusKindType,
                UserId = x.BattleNpcId,
                UserPartsUuid = x.BattleNpcPartsUuid
            })
            .ToList();
    }

    private static List<EntityIUserWeaponSkill> GetEntityIUserWeaponSkillListFromNpcTable(long npcId, string npcWeaponUuid)
    {
        return DatabaseDefine.Master.EntityMBattleNpcWeaponSkillTable.All
            .Where(x => x.BattleNpcId == npcId && x.BattleNpcWeaponUuid == npcWeaponUuid)
            .Select(x => new EntityIUserWeaponSkill()
            {
                LatestVersion = 1,
                Level = x.Level,
                SlotNumber = x.SlotNumber,
                UserId = x.BattleNpcId,
                UserWeaponUuid = x.BattleNpcWeaponUuid
            })
            .ToList();
    }

    private static List<EntityIUserWeaponAbility> GetEntityIUserWeaponAbilityListFromNpcTable(long npcId, string npcWeaponUuid)
    {
        return DatabaseDefine.Master.EntityMBattleNpcWeaponAbilityTable.All
            .Where(x => x.BattleNpcId == npcId && x.BattleNpcWeaponUuid == npcWeaponUuid)
            .Select(x => new EntityIUserWeaponAbility()
            {
                LatestVersion = 1,
                Level = x.Level,
                SlotNumber = x.SlotNumber,
                UserId = x.BattleNpcId,
                UserWeaponUuid = x.BattleNpcWeaponUuid
            })
            .ToList();
    }
}
