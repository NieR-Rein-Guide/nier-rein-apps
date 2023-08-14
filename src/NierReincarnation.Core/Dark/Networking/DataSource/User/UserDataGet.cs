using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserData;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserDataName;

namespace NierReincarnation.Core.Dark.Networking.DataSource.User;

public class UserDataGet
{
    // Custom: Return indicator if download was successful
    public async Task<bool> RequestAsync()
    {
        var userNames = await GetUserDataNameV2Api.RequestAsyncMethod();
        var mergedUserNames = userNames.SelectMany(x => x).ToList();
        if (mergedUserNames.Count == 0) return false;

        var userData = await GetUserDataApi.RequestAsyncMethod(mergedUserNames);
        if (userData == null) return false;

        DarkUserDatabaseBuilder dbBuilder = new();
        foreach (var userDataElement in userData)
        {
            dbBuilder.Append(userDataElement.Item1, userDataElement.Item2);
        }

        DatabaseDefine.User = new DarkUserMemoryDatabase(dbBuilder.Build(), false);

        return true;
    }
}
