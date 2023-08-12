using Art.Framework.ApiNetwork.Grpc.Api.Data;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.UserData.Models;

namespace NierReincarnation.UserData;

public sealed class UserData
{
    public IList<User> User { get; private set; } = new List<User>();

    public IList<UserDeck> Decks { get; private set; } = new List<UserDeck>();

    public IList<UserDeckCharacter> DeckCharacters { get; private set; } = new List<UserDeckCharacter>();

    public IList<UserDeckSubWeaponGroup> DeckSubWeaponGroups { get; private set; } = new List<UserDeckSubWeaponGroup>();

    public IList<UserDeckPartsGroup> DeckPartsGroups { get; private set; } = new List<UserDeckPartsGroup>();

    public IList<UserCharacter> Characters { get; private set; } = new List<UserCharacter>();

    public IList<UserCostume> Costumes { get; private set; } = new List<UserCostume>();

    public IList<UserCostumeBonus> CostumeBonuses { get; private set; } = new List<UserCostumeBonus>();

    public IList<UserCharacterBoardStatus> CharacterBoardStatusUp { get; private set; } = new List<UserCharacterBoardStatus>();

    public IList<UserWeapon> Weapons { get; private set; } = new List<UserWeapon>();

    public IList<UserWeaponAbility> WeaponAbilities { get; private set; } = new List<UserWeaponAbility>();

    public IList<UserCompanion> Companions { get; private set; } = new List<UserCompanion>();

    public IList<UserPart> Parts { get; private set; } = new List<UserPart>();

    private UserData(MapField<string, string> userData)
    {
        ParseData(userData);
    }

    internal static async Task<UserData> Load(DarkClient dc)
    {
        var names = await dc.GetUserDataNameAsync(new Empty());
        var data = await dc.GetUserDataAsync(new UserDataGetRequest { TableName = { names.TableName } });

        return new UserData(data.UserDataJson);
    }

    private void ParseData(MapField<string, string> userData)
    {
        var ud = userData.ToDictionary(x => x.Key, y => y.Value).OrderBy(x => x.Key);

        User = JsonConvert.DeserializeObject<IList<User>>(userData["IUser"]);
        Decks = JsonConvert.DeserializeObject<IList<UserDeck>>(userData["IUserDeck"]);
        DeckCharacters = JsonConvert.DeserializeObject<IList<UserDeckCharacter>>(userData["IUserDeckCharacter"]);
        DeckSubWeaponGroups = JsonConvert.DeserializeObject<IList<UserDeckSubWeaponGroup>>(userData["IUserDeckSubWeaponGroup"]);
        DeckPartsGroups = JsonConvert.DeserializeObject<IList<UserDeckPartsGroup>>(userData["IUserDeckPartsGroup"]);
        Characters = JsonConvert.DeserializeObject<IList<UserCharacter>>(userData["IUserCharacter"]);
        Costumes = JsonConvert.DeserializeObject<IList<UserCostume>>(userData["IUserCostume"]);
        CostumeBonuses = JsonConvert.DeserializeObject<IList<UserCostumeBonus>>(userData["IUserCharacterCostumeLevelBonus"]);
        CharacterBoardStatusUp = JsonConvert.DeserializeObject<IList<UserCharacterBoardStatus>>(userData["IUserCharacterBoardStatusUp"]);
        Weapons = JsonConvert.DeserializeObject<IList<UserWeapon>>(userData["IUserWeapon"]);
        WeaponAbilities = JsonConvert.DeserializeObject<IList<UserWeaponAbility>>(userData["IUserWeaponAbility"]);
        Companions = JsonConvert.DeserializeObject<IList<UserCompanion>>(userData["IUserCompanion"]);
        Parts = JsonConvert.DeserializeObject<IList<UserPart>>(userData["IUserParts"]);
    }
}
