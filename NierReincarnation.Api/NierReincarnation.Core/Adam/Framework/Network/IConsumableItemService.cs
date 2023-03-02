using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IConsumableItemService
    {
        Task<UseEffectItemResponse> UseEffectItemAsync(UseEffectItemRequest request);
    }
}
