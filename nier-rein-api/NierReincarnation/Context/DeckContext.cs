using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Deck;
using Newtonsoft.Json;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Context
{
    public class DeckContext : BaseContext
    {
        private readonly DarkClient _dc = new DarkClient();

        internal DeckContext() { }

        public async Task Replace(DataDeckInfo deck)
        {
            var replaceRes = await TryRequest(async () =>
            {
                var replaceReq = CreateReplaceDeckRequest(deck);
                return await _dc.DeckService.ReplaceDeckAsync(replaceReq);
            });

            foreach (var userData in replaceRes.DiffUserData)
                DatabaseDefine.User.Diff(userData.Key, JsonConvert.DeserializeObject<List<object>>(userData.Value.UpdateRecordsJson));
        }

        public async Task Rename(int userDeckNumber, DeckType deckType, string name)
        {
            // TODO: Handle request limit
            var renameRes = await TryRequest(async () =>
            {
                var renameReq = CreateUpdateNameRequest(userDeckNumber, deckType, name);
                return await _dc.DeckService.UpdateNameAsync(renameReq);
            });

            foreach (var userData in renameRes.DiffUserData)
                DatabaseDefine.User.Diff(userData.Key, JsonConvert.DeserializeObject<List<object>>(userData.Value.UpdateRecordsJson));
        }

        private UpdateNameRequest CreateUpdateNameRequest(int userDeckNumber, DeckType deckType, string name)
        {
            return new UpdateNameRequest
            {
                UserDeckNumber = userDeckNumber,
                DeckType = (int)deckType,
                Name = name
            };
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

            if (actor.DressupCostumeId <= 0)
                result.UserDressupId = actor.DressupCostumeId;

            if (actor.MainWeapon != null)
                result.MainUserWeaponUuid = actor.MainWeapon.UserWeaponUuid;

            if (actor.SubWeapon01 != null)
                result.SubUserWeaponUuid.Add(actor.SubWeapon01.UserWeaponUuid);

            if (actor.SubWeapon02 != null)
                result.SubUserWeaponUuid.Add(actor.SubWeapon02.UserWeaponUuid);

            if (actor.Companion != null)
                result.UserCompanionUuid = actor.Companion.UserCompanionUuid;

            if (actor.Thought != null)
                result.UserThoughtUuid = actor.Thought.UserThoughtUuid;

            foreach (var mem in actor.Memories.Where(m => m != null))
                result.UserPartsUuid.Add(mem.UserMemoryUuid);

            return result;
        }
    }
}
