using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.UnityEngine.Purchasing;

namespace NierReincarnation.Core.Dark.Purchase;

public class DarkPurchase
{
    private static readonly Lazy<DarkPurchase> Lazy = new Lazy<DarkPurchase>(() => new DarkPurchase());
    public static DarkPurchase Instance => Lazy.Value;

   
    private Purchaser _purchaser;
   
    private Dictionary<string, PurchaseProcessingData> _purchaseProcessingDatas;
   
    private Dictionary<string, int> _shopIdByProductId;

   
    public bool Initialized { get; private set; }

    public DarkPurchase()
    {
        _purchaseProcessingDatas = new Dictionary<string, PurchaseProcessingData>();
        _shopIdByProductId = new Dictionary<string, int>();
    }

    public async Task<PurchaseErrorType> Initialize(bool isForce = false)
    {
        if (Initialized && !isForce)
            return PurchaseErrorType.None;

        var productList = GetProducts().Select(p => $"com.square_enix.nierspww.{p.ProductIdSuffix}").ToList();
        if (productList.IsNullOrEmpty())
            return PurchaseErrorType.NoProductsAvailable;

        var userId = CalculatorStateUser.GetUserId();
        var shopIdList = CalculatorShop.CreateShopIdList(userId, ShopGroupType.PREMIUM_SHOP);
        foreach (var shopId in shopIdList)
        {
            foreach (var productId in CreateShopItemProductIdList(shopId))
            {
                var currentProductId = $"com.square_enix.nierspww.{productId}";
                if (productList.Contains(currentProductId))
                    _shopIdByProductId[currentProductId] = shopId;
            }
        }

        // TODO: Platform dependency
        _purchaser = new Purchaser();
        await _purchaser.InitializeAndroid(productList, OnInitializeProcessPurchase, true);

        Initialized = true;

        return await RecoveryProcessingPurchase();
    }

    public static List<string> CreateShopItemProductIdList(int shopId)
    {
        var shopEntity = CalculatorShop.EntityMShop(shopId);
        return CalculatorShop.ActiveEntityMShopItems(shopEntity.ShopItemCellGroupId)
            .Where(x => x.Item2.PriceType == PriceType.PLATFORM_PAYMENT)
            .OrderBy(x => x.Item1)
            .Select(x => CalculatorShop.GetProductId(x.Item2.PriceId))
            .ToList();
    }

    public async Task<PurchaseErrorType> RecoveryProcessingPurchase()
    {
        foreach (var purchaseProcessingData in _purchaseProcessingDatas.Values)
        {
            var errorType = await RecreateBridgeTransactionAsync(purchaseProcessingData.Product.definition.id);
            if (errorType != PurchaseErrorType.None)
                return errorType;

            errorType = await PurchaseReceiptAsync(purchaseProcessingData.Product, purchaseProcessingData.Product.receipt);

            //PlayerPreference.Instance.RemoveTransaction();
            //PlayerPreference.Instance.FinishTransaction();

            // AdjustSDK.TrackPurchaseEvent
            // AdjustSDK.TrackPurchaseRevenueEvent
        }

        //PlayerPreference.Instance.DeleteProductTransactions();

        return PurchaseErrorType.None;
    }

    public Task<PurchaseErrorType> PurchaseRealProductAsync(int shopItemId, string productIdSuffix, int shopId, decimal price)
    {
        // STUB
        return Task.FromResult(PurchaseErrorType.None);
    }

    public Task HandlingPurchaseError(PurchaseErrorType errorType, Action onRetryComplete)
    {
        // STUB: Entry point of research!
        return Task.CompletedTask;
    }

    private void OnInitializeProcessPurchase(Product product)
    {
        if (_purchaseProcessingDatas.ContainsKey(product.transactionID))
            return;

        _purchaseProcessingDatas[product.transactionID] = new PurchaseProcessingData(product);
    }

    private Task<PurchaseErrorType> RecreateBridgeTransactionAsync(string productId)
    {
        // CreateBridgeTransactionAsync
        //foreach (var shopItem in GetShopItems())
        //{
        //    if (!TryGetProduct(shopItem, out var product))
        //        continue;

        //    var localProductId = $"com.square_enix.nierspww.{product.ProductIdSuffix}";
        //    if (productId != localProductId)
        //        continue;

        //    shopItem.ShopItemId;

        //}

        //return PurchaseErrorType.PurchaseUnknownFailure;

        // STUB
        return Task.FromResult(PurchaseErrorType.None);
    }

    private Task<PurchaseErrorType> PurchaseReceiptAsync(Product product, string iapReceipt)
    {
        // STUB
        return Task.FromResult(PurchaseErrorType.None);
    }

    // Tuple.2 CreatePurchaseTransactionResponse
    private Task<(PurchaseErrorType, string)> CreateBridgeTransactionAsync(string productId, int shopId, int shopItemId)
    {
        // STUB
        return Task.FromResult((PurchaseErrorType.None, string.Empty));
    }

    private IEnumerable<EntityMPlatformPayment> GetProducts()
    {
        foreach (var shopItem in GetShopItems())
            if (TryGetProduct(shopItem, out var platform))
                yield return platform;
    }

    private IEnumerable<EntityMShopItem> GetShopItems()
    {
        var table = DatabaseDefine.Master.EntityMShopItemTable;
        return table.All;
    }

    // TODO: Platform dependency from Google Playstore
    private bool TryGetProduct(EntityMShopItem shopItem, out EntityMPlatformPayment product)
    {
        var table = DatabaseDefine.Master.EntityMPlatformPaymentTable;
        product = table.FindByPlatformPaymentIdAndPlatformType((shopItem.PriceId, PlatformType.GOOGLE_PLAY_STORE));

        return product != null;
    }

    public bool IsExistsProduct(string productIdSuffix)
    {
        return _shopIdByProductId.ContainsKey($"com.square_enix.nierspww.{productIdSuffix}");
    }

    public string GetStorePriceString(string productIdSuffix)
    {
        // STUB
        return string.Empty;
    }

    public enum PurchaseErrorType
    {
        None = 0,
        PurchasingUnavailable = 1,
        NoProductsAvailable = 2,
        AppNotKnown = 3,
        ExistingPurchasePending = 4,
        ProductUnavailable = 5,
        SignatureInvalid = 6,
        PaymentDeclined = 7,
        DuplicateTransaction = 8,
        PurchaseUnknownFailure = 9,
        ReceiptParseError = 10,
        AlreadyPurchasedError = 11,
        InitializeTimeoutError = 12,
        UserCancelled = 13,
        PurchaseCesaLimit = 14,
        PurchaseTooManyRefund = 15,
        PurchaseSystemError = 16,
        PurchaseDuplicateError = 17,
    }
}
