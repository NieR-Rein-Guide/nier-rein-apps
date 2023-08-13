using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserData;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserDataName;

namespace NierReincarnation.Core.Dark.Networking.DataSource.User;

public class UserDataGet
{
    // Custom: Return indicator if download was successful
    public async Task<bool> RequestAsync()
    {
        var userNames = await GetUserDataNameApi.RequestAsyncMethod();
        if (userNames == null) return false;

        var userData = await GetUserDataApi.RequestAsyncMethod(userNames);
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
