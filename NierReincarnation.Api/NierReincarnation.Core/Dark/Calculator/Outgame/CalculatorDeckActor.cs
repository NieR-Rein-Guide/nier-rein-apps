using System.Linq;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.MasterMemory;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorDeckActor // TypeDefIndex: 18807
    {
        // Fields
        public static readonly int ControlCharacterIndex = 0;
        public static readonly int kSubWeaponMaxCount = 2;

        // CUSTOM: Create actors base info
        public static DataDeckActorInfo[] CreateDataDeckActorInfo(EntityIUserDeck entityIUserDeck)
        {
            var result = new DataDeckActorInfo[3];

            var char1 = entityIUserDeck.UserDeckCharacterUuid01;
            var char2 = entityIUserDeck.UserDeckCharacterUuid02;
            var char3 = entityIUserDeck.UserDeckCharacterUuid03;

            result[0] = CreateDataDeckActorInfo(entityIUserDeck.UserId, char1);
            result[1] = CreateDataDeckActorInfo(entityIUserDeck.UserId, char2);
            result[2] = CreateDataDeckActorInfo(entityIUserDeck.UserId, char3);

            return result;
        }

        // CUSTOM: Create actor base info
        private static DataDeckActorInfo CreateDataDeckActorInfo(long userId, string characterUuid)
        {
            var characterTable = DatabaseDefine.User.EntityIUserDeckCharacterTable;
            var character = characterTable.FindByUserIdAndUserDeckCharacterUuid((userId, characterUuid));
            if (character == null)
                return null;

            var costumeTable = DatabaseDefine.User.EntityIUserCostumeTable;
            var costume = costumeTable.FindByUserIdAndUserCostumeUuid((userId, character.UserCostumeUuid));
            if (costume == null)
                return null;

            var subWeapon1 = DatabaseDefine.User.EntityIUserDeckSubWeaponGroupTable.All.FirstOrDefault(w => w.UserId == userId && w.UserDeckCharacterUuid == characterUuid && w.SortOrder == 1);
            var subWeapon2 = DatabaseDefine.User.EntityIUserDeckSubWeaponGroupTable.All.FirstOrDefault(w => w.UserId == userId && w.UserDeckCharacterUuid == characterUuid && w.SortOrder == 2);

            var actor = new DataDeckActorInfo
            {
                Costume = CalculatorCostume.CreateDataOutgameCostumeInfo(userId, character.UserCostumeUuid),
                DressupCostumeId = GetDressupCostumeId(userId, character.UserDeckCharacterUuid),
                MainWeapon = CalculatorWeapon.CreateDataWeaponInfo(userId, character.MainUserWeaponUuid),
                SubWeapon01 = CalculatorWeapon.CreateDataWeaponInfo(userId, subWeapon1?.UserWeaponUuid),
                SubWeapon02 = CalculatorWeapon.CreateDataWeaponInfo(userId, subWeapon2?.UserWeaponUuid),
                Companion = CalculatorCompanion.CreateDataOutgameCompanionInfo(userId, character.UserCompanionUuid),
                Thought = CalculatorThought.CreateDataOutgameThoughtInfo(userId, character.UserThoughtUuid)
            };

            foreach (var part in DatabaseDefine.User.EntityIUserDeckPartsGroupTable.All.Where(p => p.UserId == userId && p.UserDeckCharacterUuid == characterUuid))
            {
                if (part.SortOrder - 1 >= 3)
                    continue;

                actor.Memories[part.SortOrder - 1] = CalculatorMemory.CreateDataOutgameMemoryInfo(userId, part.UserPartsUuid);
            }

            return actor;
        }

        public static DataDeckActor CreateDataDeckActor(long userId, string userDeckCharacterUuid, RangeView<EntityIUserDeckSubWeaponGroup> subWeapons, RangeView<EntityIUserDeckPartsGroup> parts)
        {
            if (string.IsNullOrEmpty(userDeckCharacterUuid))
                return null;

            var character = DatabaseDefine.User.EntityIUserDeckCharacterTable.FindByUserIdAndUserDeckCharacterUuid((userId, userDeckCharacterUuid));
            if (character == null)
                return null;

            return CreateDataDeckActor(userId, character, subWeapons, parts);
        }

        private static DataDeckActor CreateDataDeckActor(long userId, EntityIUserDeckCharacter actor, RangeView<EntityIUserDeckSubWeaponGroup> subWeapons, RangeView<EntityIUserDeckPartsGroup> parts)
        {
            var result = new DataDeckActor
            {
                UserDeckActorUuid = actor.UserDeckCharacterUuid,
                Costume = CalculatorCostume.CreateDataOutgameCostume(userId, actor.UserCostumeUuid),
                DressupCostumeId = GetDressupCostumeId(userId, actor.UserDeckCharacterUuid),
                MainWeapon = CalculatorWeapon.CreateDataWeapon(userId, actor.MainUserWeaponUuid),
                Companion = CalculatorCompanion.CreateDataOutgameCompanion(userId, actor.UserCompanionUuid),
                Thought = CalculatorThought.CreateDataOutgameThought(userId, actor.UserThoughtUuid)
            };

            var subWeapon1 = subWeapons.FirstOrDefault(w => w.UserId == userId && w.UserDeckCharacterUuid == actor.UserDeckCharacterUuid && w.SortOrder == 1);
            if (subWeapon1 != null)
                result.SubWeapon01 = CalculatorWeapon.CreateDataWeapon(userId, subWeapon1.UserWeaponUuid);

            var subWeapon2 = subWeapons.FirstOrDefault(w => w.UserId == userId && w.UserDeckCharacterUuid == actor.UserDeckCharacterUuid && w.SortOrder == 2);
            if (subWeapon2 != null)
                result.SubWeapon02 = CalculatorWeapon.CreateDataWeapon(userId, subWeapon2.UserWeaponUuid);

            foreach (var part in parts.Where(p => p.UserId == userId && p.UserDeckCharacterUuid == actor.UserDeckCharacterUuid))
            {
                if (part.SortOrder - 1 >= 3)
                    continue;

                result.Memories[part.SortOrder - 1] = CalculatorMemory.CreateDataOutgameMemory(userId, part.UserPartsUuid);
            }

            return result;
        }

        private static int GetDressupCostumeId(long userId, string userDeckCharacterUuid)
        {
            if (!TryGetDressupCostume(userId, userDeckCharacterUuid, out var dressupCostume))
                return CalculatorCostume.kDefaultDressupCostumeId;

            return dressupCostume.DressupCostumeId;
        }

        private static bool TryGetDressupCostume(long userId, string userDeckCharacterUuid, out EntityIUserDeckCharacterDressupCostume iUserDressupCostume)
        {
            var table = DatabaseDefine.User.EntityIUserDeckCharacterDressupCostumeTable;
            return table.TryFindByUserIdAndUserDeckCharacterUuid((userId, userDeckCharacterUuid), out iUserDressupCostume);
        }
    }
}
