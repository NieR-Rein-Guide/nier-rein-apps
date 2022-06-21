using System.Collections.Generic;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Deck;
using Newtonsoft.Json;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Preference;

namespace NierReincarnation.Context
{
    public class DeckContext
    {
        private readonly DarkClient _dc = new DarkClient();

        internal DeckContext() { }

        public async Task Replace(DataDeckInfo deck)
        {
            // TODO: Handle request limit
            var replaceReq = CreateReplaceDeckRequest(deck);
            var replaceRes = await _dc.DeckService.ReplaceDeckAsync(replaceReq);

            foreach (var userData in replaceRes.DiffUserData)
                DatabaseDefine.User.Diff(userData.Key, JsonConvert.DeserializeObject<List<object>>(userData.Value.UpdateRecordsJson));
        }

        public IEnumerable<DataDeck> GetQuestDecks()
        {
            return CalculatorDeck.EnumerateDeckDataList(PlayerPreference.Instance.ActivePlayer.UserId, DeckType.QUEST);
        }

        public IEnumerable<DataDeckInfo> GetQuestDeckInfo()
        {
            return CalculatorDeck.EnumerateDeckInfo(PlayerPreference.Instance.ActivePlayer.UserId, DeckType.QUEST);
        }

        public DataDeck GetQuestDeck(int deckNumber, DeckType deckType)
        {
            return CalculatorDeck.CreateDataDeck(PlayerPreference.Instance.ActivePlayer.UserId, deckNumber, deckType);
        }

        private ReplaceDeckRequest CreateReplaceDeckRequest(DataDeckInfo deck)
        {
            var result = new ReplaceDeckRequest
            {
                UserDeckNumber = deck.UserDeckNumber,
                DeckType = (int)deck.DeckType,
                Deck = new Deck()
            };

            for (var i = 0; i < deck.UserDeckActors.Length; i++)
            {
                var actor = deck.UserDeckActors[i];
                if (actor == null)
                    continue;

                switch (i)
                {
                    case 0:
                        result.Deck.Character01 = CreateDeckCharacter(actor);
                        break;

                    case 1:
                        result.Deck.Character02 = CreateDeckCharacter(actor);
                        break;

                    default:
                        result.Deck.Character03 = CreateDeckCharacter(actor);
                        break;
                }
            }

            return result;
        }

        private DeckCharacter CreateDeckCharacter(DataDeckActorInfo actor)
        {
            var result = new DeckCharacter();

            if (actor.Costume != null)
                result.UserCostumeUuid = actor.Costume.UserCostumeUuid;

            if (actor.MainWeapon != null)
                result.MainUserWeaponUuid = actor.MainWeapon.UserWeaponUuid;

            if (actor.SubWeapon01 != null)
                result.SubUserWeaponUuid.Add(actor.SubWeapon01.UserWeaponUuid);

            if (actor.SubWeapon02 != null)
                result.SubUserWeaponUuid.Add(actor.SubWeapon02.UserWeaponUuid);

            if (actor.Companion != null)
                result.UserCompanionUuid = actor.Companion.UserCompanionUuid;

            foreach (var mem in actor.Memories)
                result.UserPartsUuid.Add(mem.UserMemoryUuid);

            return result;
        }
    }
}
