using System.Linq;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Deck;
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
            await TryRequest(async () =>
            {
                var replaceReq = CreateReplaceDeckRequest(deck);
                return await _dc.DeckService.ReplaceDeckAsync(replaceReq);
            });
        }

        public async Task Rename(int userDeckNumber, DeckType deckType, string name)
        {
            await TryRequest(async () =>
            {
                var renameReq = CreateUpdateNameRequest(userDeckNumber, deckType, name);
                return await _dc.DeckService.UpdateNameAsync(renameReq);
            });
        }

        public async Task Remove(int userDeckNumber, DeckType deckType)
        {
            await TryRequest(async () =>
            {
                var removeReq = CreateRemoveDeckRequest(userDeckNumber, deckType);
                return await _dc.DeckService.RemoveDeckAsync(removeReq);
            });
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

        private RemoveDeckRequest CreateRemoveDeckRequest(int userDeckNumber, DeckType deckType)
        {
            return new RemoveDeckRequest
            {
                UserDeckNumber = userDeckNumber,
                DeckType = (int)deckType
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
