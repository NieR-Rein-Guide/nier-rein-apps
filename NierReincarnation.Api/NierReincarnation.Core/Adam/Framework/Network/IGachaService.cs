using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Gacha;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IGachaService
    {
        public Task<GetGachaListResponse> GetGachaListAsync(GetGachaListRequest request);

        public Task<GetGachaResponse> GetGachaAsync(GetGachaRequest request);

        //public abstract Task<DrawResponse> DrawAsync(DrawRequest request);

        //public abstract Task<ResetBoxGachaResponse> ResetBoxGachaAsync(ResetBoxGachaRequest request);

        //public abstract Task<GetRewardGachaResponse> GetRewardGachaAsync(Empty request);

        //public abstract Task<RewardDrawResponse> RewardDrawAsync(RewardDrawRequest request);
	}
}
