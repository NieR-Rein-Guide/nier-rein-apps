using System.Collections.Generic;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Data;
using NierReincarnation.Core.Adam.Framework.Network;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserData
{
    class GetUserDataApi
    {
        // CUSTOM: Return list of objects to parse them into a safe type later
        public static async Task<(string, List<object>)[]> RequestAsyncMethod(IReadOnlyList<string> tableNames)
        {
            var dc = new DarkClient();
            var userData = await dc.DataService.GetUserDataAsync(new UserDataGetRequest { TableName = { tableNames } });
            if (userData == null)
                return null;

            var result = new List<(string, List<object>)>();
            foreach (var userDataElement in userData.UserDataJson)
                result.Add((userDataElement.Key, Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(userDataElement.Value)));

            return result.ToArray();
        }
    }
}
