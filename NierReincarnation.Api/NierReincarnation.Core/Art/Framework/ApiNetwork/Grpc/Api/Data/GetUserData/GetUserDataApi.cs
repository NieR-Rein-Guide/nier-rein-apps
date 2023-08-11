using Art.Framework.ApiNetwork.Grpc.Api.Data;
using NierReincarnation.Core.Adam.Framework.Network;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserData;

public class GetUserDataApi
{
    // CUSTOM: Return list of objects to parse them into a safe type later
    public static async Task<(string, List<object>)[]> RequestAsyncMethod(IReadOnlyList<string> tableNames)
    {
        DarkClient darkClient = new();
        var userData = await darkClient.DataService.GetUserDataAsync(new UserDataGetRequest { TableName = { tableNames } });
        if (userData == null)
        {
            return null;
        }

        List<(string, List<object>)> result = new();
        foreach (var userDataElement in userData.UserDataJson)
        {
            result.Add((userDataElement.Key, JsonConvert.DeserializeObject<List<object>>(userDataElement.Value)));
        }

        return result.ToArray();
    }
}
