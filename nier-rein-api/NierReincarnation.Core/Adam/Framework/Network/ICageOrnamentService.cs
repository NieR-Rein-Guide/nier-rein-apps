using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.CageOrnament;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface ICageOrnamentService
    {
        Task<ReceiveRewardResponse> ReceiveRewardAsync(ReceiveRewardRequest request);
    }
}
