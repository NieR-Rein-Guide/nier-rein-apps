using System.Linq;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Deck;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
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
            if (deckType == DeckType.RESTRICTED_QUEST)
            {
                await RemoveRestricted(userDeckNumber);
                return;
            }

            await TryRequest(async () =>
            {
                var removeReq = CreateRemoveDeckRequest(userDeckNumber, deckType);
                return await _dc.DeckService.RemoveDeckAsync(removeReq);
            }, deckType != DeckType.RESTRICTED_LIMIT_CONTENT_QUEST);

            // Manually remove deck from user database
            // HINT: We can delete restricted decks for recollections of dusk with this, however we do not receive a valid response, so we take care of the user database ourselves
            var deckData = DatabaseDefine.User.EntityIUserDeckTable.GetRawDataUnsafe();
            deckData = deckData.Where(x => x.DeckType != deckType || x.UserDeckNumber != userDeckNumber).ToArray();
            DatabaseDefine.User.EntityIUserDeckTable.SetRawDataUnsafe(deckData);
        }

        private async Task RemoveRestricted(int userDeckNumber)
        {
            // HINT: This only performs "Remove All", since a restricted deck cannot be fully removed by the API
            var restrictedDeck = CalculatorDeck.CreateDataDeckInfo(CalculatorStateUser.GetUserId(), userDeckNumber, DeckType.RESTRICTED_QUEST);

            var mainActor = restrictedDeck.UserDeckActors[0];
            mainActor.SubWeapon01 = null;
            mainActor.SubWeapon02 = null;
            mainActor.Companion = null;
            mainActor.Memories[0] = null;
            mainActor.Memories[1] = null;
            mainActor.Memories[2] = null;
            mainActor.Thought = null;
            mainActor.DressupCostumeId = 0;

            restrictedDeck.UserDeckActors[1] = null;
            restrictedDeck.UserDeckActors[2] = null;

            await Replace(restrictedDeck);
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

            if (actor.DressupCostumeId >= 0)
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
