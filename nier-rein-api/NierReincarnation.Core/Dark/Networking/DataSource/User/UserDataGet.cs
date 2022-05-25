using System.Threading.Tasks;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserData;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserDataName;

namespace NierReincarnation.Core.Dark.Networking.DataSource.User
{
    // Dark.Networking.DataSource.User
    class UserDataGet
    {
        public async Task RequestAsync()
        {
            var userNames = await GetUserDataNameApi.RequestAsyncMethod();
            var userData = await GetUserDataApi.RequestAsyncMethod(userNames);

            var dbBuilder = new DarkUserDatabaseBuilder();
            foreach (var userDataElement in userData)
                dbBuilder.Append(userDataElement.Item1, userDataElement.Item2);

            DatabaseDefine.User = new DarkUserMemoryDatabase(dbBuilder.Build(), false);
        }
    }
}
