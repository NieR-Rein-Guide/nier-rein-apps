using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Deck;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IDeckService
    {
        public Task<UpdateNameResponse> UpdateNameAsync(UpdateNameRequest request);

        public Task<ReplaceDeckResponse> ReplaceDeckAsync(ReplaceDeckRequest request);
    }
}
