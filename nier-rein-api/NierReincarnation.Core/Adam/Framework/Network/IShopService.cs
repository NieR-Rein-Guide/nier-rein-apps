using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Shop;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IShopService
    {
        Task<CreatePurchaseTransactionResponse> CreatePurchaseTransactionAsync(CreatePurchaseTransactionRequest request);
    }
}
