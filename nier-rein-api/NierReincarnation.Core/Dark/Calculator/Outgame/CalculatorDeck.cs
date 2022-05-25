using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorDeck
    {
        public static readonly int InitialDeckNumber = 1; // 0x0
        public static readonly int InvalidDeckNumber = -1; // 0x4
        public static readonly int LowerLimitChangeCharaDeckActorCount = 2; // 0x8
        public static readonly int kTripleDeckWaveCount = 3; // 0xC
        public static readonly int kInvalidWaveIndex = -1; // 0x10
        public static readonly int kMinWaveIndex = 0; // 0x14
        private static readonly int kInitialDeckActorNumber = 0; // 0x18
        public static readonly int kInvalidDeckActorIndex = -1; // 0x1C
        private static readonly int kWaveIndexToWaveNumberAddValue = 1; // 0x20
        private static readonly int kUserDeckNumberTripleDeckToWaveDeckValue = 100; // 0x24
        private static readonly string kWaveDeckNameFormat = "{0}{1}ï¼{2}"; // 0x28

        // CUSTOM: Enumerates all decks with shallow information; Returning efficiently acquired information such as ID and name
        public static IEnumerable<DataDeck> EnumerateDeckInfo(long userId, DeckType deckType)
        {
            foreach (var deck in DatabaseDefine.User.EntityIUserDeckTable.All)
            {
                if (deck.UserId != userId || deck.DeckType != deckType)
                    continue;

                yield return new DataDeck
                {
                    Name = deck.Name,
                    UserDeckNumber = deck.UserDeckNumber
                };
            }
        }

        // CUSTOM: Get enumerable list of type restricted decks
        public static IEnumerable<DataDeck> EnumerateDeckDataList(long userId, DeckType deckType)
        {
            foreach (var deck in DatabaseDefine.User.EntityIUserDeckTable.All)
            {
                if (deck.UserId != userId || deck.DeckType != deckType)
                    continue;

                yield return CreateDataDeck(userId, deck);
            }
        }

        public static List<DataDeck> CreateDataDeckList(long userId)
        {
            var result = new List<DataDeck>();
            foreach (var deck in DatabaseDefine.User.EntityIUserDeckTable.All)
            {
                if (deck.UserId != userId)
                    continue;

                var dataDeck = CreateDataDeck(userId, deck);
                result.Add(dataDeck);
            }

            return result;
        }

        public static DataDeck CreateDataDeck(long userId, int deckNumber, DeckType deckType)
        {
            var deck = DatabaseDefine.User.EntityIUserDeckTable.FindByUserIdAndDeckTypeAndUserDeckNumber((userId, deckType, deckNumber));
            var dataDeck = CreateDataDeck(userId, deck);

            return dataDeck;
        }

        private static DataDeck CreateDataDeck(long userId, EntityIUserDeck entityIUserDeck)
        {
            var result = new DataDeck(entityIUserDeck.DeckType, entityIUserDeck.UserDeckNumber)
            {
                Name = entityIUserDeck.Name
            };

            var subWeaponGroups = DatabaseDefine.User.EntityIUserDeckSubWeaponGroupTable.All;
            var partsGroups = DatabaseDefine.User.EntityIUserDeckPartsGroupTable.All;

            var char1 = entityIUserDeck.UserDeckCharacterUuid01;
            var char2 = entityIUserDeck.UserDeckCharacterUuid02;
            var char3 = entityIUserDeck.UserDeckCharacterUuid03;

            result.UserDeckActors[0] = CalculatorDeckActor.CreateDataDeckActor(userId, char1, subWeaponGroups, partsGroups);
            result.UserDeckActors[1] = CalculatorDeckActor.CreateDataDeckActor(userId, char2, subWeaponGroups, partsGroups);
            result.UserDeckActors[2] = CalculatorDeckActor.CreateDataDeckActor(userId, char3, subWeaponGroups, partsGroups);

            UpdatePower(userId, result);

            // CUSTOM: Set the status values for the actor view in "Loadouts"
            if (result.UserDeckActors[0] != null)
                result.UserDeckActors[0].StatusValue = CalculatorStatusOutgame.GetDeckActorStatus(userId, result.UserDeckActors[0]);
            if (result.UserDeckActors[1] != null)
                result.UserDeckActors[1].StatusValue = CalculatorStatusOutgame.GetDeckActorStatus(userId, result.UserDeckActors[1]);
            if (result.UserDeckActors[2] != null)
                result.UserDeckActors[2].StatusValue = CalculatorStatusOutgame.GetDeckActorStatus(userId, result.UserDeckActors[2]);

            return result;
        }

        public static void UpdatePower(long userId, DataDeck deck)
        {
            foreach (var actor in deck.UserDeckActors)
            {
                if (actor == null)
                    continue;

                var abilities = CalculatorMemory.CreateMemorySeriesBonusDataAbility(actor.Memories);
                actor.MemorySeriesBonus = abilities.ToArray();
            }

            CalculatorStatusOutgame.ApplyDeckAbilityStatusList(userId, deck);

            foreach (var actor in deck.UserDeckActors)
                if (actor != null)
                    actor.Power = CalculatorPower.CalculateDeckActorPower(userId, actor, deck);

            deck.Power = CalculatorPower.CalculateDeckPower(userId, deck);
        }
    }
}
