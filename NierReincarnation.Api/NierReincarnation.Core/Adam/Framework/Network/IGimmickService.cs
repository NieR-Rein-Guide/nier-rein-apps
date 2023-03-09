using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Gimmick;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IGimmickService
    {
        Task<UpdateGimmickProgressResponse> UpdateGimmickProgressAsync(UpdateGimmickProgressRequest request);
    }
}
