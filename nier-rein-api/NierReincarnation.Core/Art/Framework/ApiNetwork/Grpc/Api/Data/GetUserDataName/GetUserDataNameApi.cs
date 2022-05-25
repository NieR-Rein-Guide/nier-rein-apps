using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using NierReincarnation.Core.Adam.Framework.Network;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api.Data.GetUserDataName
{
    class GetUserDataNameApi
    {
        public static async Task<List<string>> RequestAsyncMethod()
        {
            var dc = new DarkClient();
            return (await dc.DataService.GetUserDataNameAsync(new Empty())).TableName.ToList();
        }
    }
}
