using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorNpcDeck
    {
        public static DataDeck CreateNpcDataDeck(long npcUserId, EntityIUserDeck entityIUserDeck)
        {
            if (entityIUserDeck == null)
                return null;

            var deckType = entityIUserDeck.DeckType;
            var deckNumber = entityIUserDeck.UserDeckNumber;

            var result = new DataDeck
            {
                DeckType = deckType,
                UserDeckNumber = deckNumber,
                Name = UserInterfaceTextKey.Deck.kRentalDeck.Localize(),
                UserDeckActors =
                {
                    [0] = CreateNpcDataDeckActor(npcUserId, entityIUserDeck.UserDeckCharacterUuid01),
                    [1] = CreateNpcDataDeckActor(npcUserId, entityIUserDeck.UserDeckCharacterUuid02),
                    [2] = CreateNpcDataDeckActor(npcUserId, entityIUserDeck.UserDeckCharacterUuid03)
                },
                Power = entityIUserDeck.Power
            };

            // CUSTOM: Set the status values for the actors
            if (result.UserDeckActors[0] != null)
                result.UserDeckActors[0].StatusValue = CalculatorStatusOutgame.GetDeckActorStatus(npcUserId, result.UserDeckActors[0]);
            if (result.UserDeckActors[1] != null)
                result.UserDeckActors[1].StatusValue = CalculatorStatusOutgame.GetDeckActorStatus(npcUserId, result.UserDeckActors[1]);
            if (result.UserDeckActors[2] != null)
                result.UserDeckActors[2].StatusValue = CalculatorStatusOutgame.GetDeckActorStatus(npcUserId, result.UserDeckActors[2]);

            return result;
        }

        private static DataDeckActor CreateNpcDataDeckActor(long userId, string userDeckCharacterUuid)
        {
            if (string.IsNullOrEmpty(userDeckCharacterUuid))
                return null;

            var table = DatabaseDefine.Master.EntityMBattleNpcDeckCharacterTable;
            var npcChar = table.FindByBattleNpcIdAndBattleNpcDeckCharacterUuid((userId, userDeckCharacterUuid));

            return CreateDataDeckActor(userId, npcChar);
        }

        private static DataDeckActor CreateDataDeckActor(long userId, EntityMBattleNpcDeckCharacter entityMBattleNpcDeckCharacter)
        {
            var result = new DataDeckActor { UserDeckActorUuid = entityMBattleNpcDeckCharacter.BattleNpcDeckCharacterUuid };
            SetDataDeckActorData(userId, result, entityMBattleNpcDeckCharacter);

            return result;
        }

        private static void SetDataDeckActorData(long userId, DataDeckActor dataDeckActor, EntityMBattleNpcDeckCharacter entityIUserDeckCharacter)
        {
            dataDeckActor.Power = entityIUserDeckCharacter.Power;

            var table = DatabaseDefine.Master.EntityMBattleNpcCostumeTable;
            var npcCostume = table.FindByBattleNpcIdAndBattleNpcCostumeUuid((userId, entityIUserDeckCharacter.BattleNpcCostumeUuid));
            dataDeckActor.Costume = CalculatorCostume.CreateDataOutgameCostume(npcCostume);

            var table1 = DatabaseDefine.Master.EntityMBattleNpcWeaponTable;
            var npcWeapon = table1.FindByBattleNpcIdAndBattleNpcWeaponUuid((userId, entityIUserDeckCharacter.MainBattleNpcWeaponUuid));
            dataDeckActor.MainWeapon = CalculatorWeapon.CreateNpcWeapon(npcWeapon);

            var table2 = DatabaseDefine.Master.EntityMBattleNpcCompanionTable;
            var npcCompanion = table2.FindByBattleNpcIdAndBattleNpcCompanionUuid((userId, entityIUserDeckCharacter.BattleNpcCompanionUuid));
            if(npcCompanion==null)
                return;

            dataDeckActor.Companion = CalculatorCompanion.CreateDataOutgameNpcCompanion(npcCompanion);
        }
    }
}
