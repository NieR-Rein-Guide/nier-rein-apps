using Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IConsumableItemService
{
    public abstract Task<UseEffectItemResponse> UseEffectItemAsync(UseEffectItemRequest request);

    //public abstract Task<SellResponse> SellAsync(SellRequest request);
}
