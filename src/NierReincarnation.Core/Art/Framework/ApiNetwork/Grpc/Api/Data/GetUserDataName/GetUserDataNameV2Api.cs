using Google.Protobuf.WellKnownTypes;
using NierReincarnation.Core.Adam.Framework.Network;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserDataName;

public class GetUserDataNameV2Api
{
    public static async Task<List<List<string>>> RequestAsyncMethod()
    {
        DarkClient darkClient = new();
        var result = await darkClient.DataService.GetUserDataNameV2Async(new Empty());

        return result?.TableNameList.Select(x => x.TableName.ToList()).ToList() ?? new();
    }
}
