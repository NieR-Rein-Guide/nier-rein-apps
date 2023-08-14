using Google.Protobuf.WellKnownTypes;
using NierReincarnation.Core.Adam.Framework.Network;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserDataName;

public class GetUserDataNameApi
{
    public static async Task<List<string>> RequestAsyncMethod()
    {
        DarkClient darkClient = new();
        var result = await darkClient.DataService.GetUserDataNameAsync(new Empty());

        return result?.TableName.ToList() ?? new();
    }
}
