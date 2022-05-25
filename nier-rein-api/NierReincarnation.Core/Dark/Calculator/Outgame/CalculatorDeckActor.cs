using System;
using System.Linq;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.MasterMemory;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorDeckActor // TypeDefIndex: 18807
    {
        // Fields
        public static readonly int ControlCharacterIndex = 0; // 0x0
        public static readonly int kSubWeaponMaxCount = 2; // 0x4

        // Methods

        public static DataDeckActor CreateDataDeckActor(long userId, string userDeckCharacterUuid, RangeView<EntityIUserDeckSubWeaponGroup> subWeapons, RangeView<EntityIUserDeckPartsGroup> parts)
        {
            if (string.IsNullOrEmpty(userDeckCharacterUuid))
                return null;

            if (DatabaseDefine.User?.EntityIUserDeckCharacterTable == null)
                throw new ArgumentNullException();

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
                MainWeapon = CalculatorWeapon.CreateDataWeapon(userId, actor.MainUserWeaponUuid),
                Companion = CalculatorCompanion.CreateDataOutgameCompanion(userId, actor.UserCompanionUuid)
            };

            var subWeapon1 = subWeapons.FirstOrDefault(w => w.UserId == userId && w.SortOrder == 1);
            if (subWeapon1 != null)
                result.SubWeapon01 = CalculatorWeapon.CreateDataWeapon(userId, subWeapon1.UserWeaponUuid);

            var subWeapon2 = subWeapons.FirstOrDefault(w => w.UserId == userId && w.SortOrder == 2);
            if (subWeapon2 != null)
                result.SubWeapon02 = CalculatorWeapon.CreateDataWeapon(userId, subWeapon2.UserWeaponUuid);

            foreach (var part in parts.Where(p => p.UserId == userId && p.UserDeckCharacterUuid == actor.UserCostumeUuid))
            {
                if (part.SortOrder - 1 >= 3)
                    continue;

                result.Memories[part.SortOrder - 1] = CalculatorMemory.CreateDataOutgameMemory(userId, part.UserPartsUuid);
            }

            return result;
        }
    }
}
