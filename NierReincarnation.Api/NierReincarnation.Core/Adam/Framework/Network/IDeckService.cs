using Art.Framework.ApiNetwork.Grpc.Api.Deck;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IDeckService
{
    public abstract Task<UpdateNameResponse> UpdateNameAsync(UpdateNameRequest request);

    public abstract Task<ReplaceDeckResponse> ReplaceDeckAsync(ReplaceDeckRequest request);

    //public abstract Task<SetPvpDefenseDeckResponse> SetPvpDefenseDeckAsync(SetPvpDefenseDeckRequest request);

    //public abstract Task<CopyDeckResponse> CopyDeckAsync(CopyDeckRequest request);

    public abstract Task<RemoveDeckResponse> RemoveDeckAsync(RemoveDeckRequest request);

    //public abstract Task<RefreshDeckPowerResponse> RefreshDeckPowerAsync(RefreshDeckPowerRequest request);

    //public abstract Task<UpdateTripleDeckNameResponse> UpdateTripleDeckNameAsync(UpdateTripleDeckNameRequest request);

    //public abstract Task<ReplaceTripleDeckResponse> ReplaceTripleDeckAsync(ReplaceTripleDeckRequest request);

    //public abstract Task<RefreshMultiDeckPowerResponse> RefreshMultiDeckPowerAsync(RefreshMultiDeckPowerRequest request);
}
