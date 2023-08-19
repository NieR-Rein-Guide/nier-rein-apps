using Grpc.Core;
using NierReincarnation.Api.Authentication;
using NierReincarnation.Api.Exceptions;
using NierReincarnation.Context;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Adam.Framework.Network.Interceptors;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Art.Library.Masterdata.Download;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Dark.Kernel;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.Networking.DataSource.User;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Localizations;
using Config = NierReincarnation.Core.Dark.EntryPoint.Config;

namespace NierReincarnation;

public static class NierReincarnationApp
{
    private const int RetryCount = 3;

    public static NotificationContext Notifications { get; } = new NotificationContext();

    public static AssetContext Assets { get; } = new AssetContext();

    public static bool IsSetup { get; private set; }

    public static bool IsLoggedIn => PlayerPrefs.Exists;

    public static bool IsAuthorized { get; set; }

    public static bool IsInitialized { get; set; }

    public static event Func<RpcException, Task<bool>> NetworkErrorEvent;

    public static RpcException LastNetworkError { get; private set; }

    static NierReincarnationApp()
    {
        Generator.OnEntrypoint();

        DarkOctoSetupper.StartSetup(!OctoManager.IsSetupped, true);
    }

    public static NierReinContexts GetContexts()
    {
        if (!IsInitialized)
            throw new InvalidOperationException("Initialize the application first before accessing its functions.");

        return new NierReinContexts();
    }

    public static async Task InitializeApplicationAsync(ApplicationInitArguments args)
    {
        // Setup application systems
        SetupApplicationSystems(args);

        // Login user
        await LoginAsync(args);

        // Setup master and user data
        await SetupMasterAndUserDataAsync(args);
    }

    public static async Task LoadLocalizations(SystemLanguage lang)
    {
        if (!IsInitialized)
        {
            throw new ApiException("Cannot load localizations because the application is not initialized");
        }

        // Update text assets and load localizations
        AssetContext assetContext = new();
        await assetContext.DownloadTextAssets(lang);

        LocalizationExtensions.Localizations = TextLocalizer.Create(lang);
    }

    public static void ResetApplication()
    {
        IsSetup = false;
        IsInitialized = false;
        IsAuthorized = false;
    }

    private static void SetupApplicationSystems(ApplicationInitArguments args)
    {
        if (IsSetup) return;

        // Setup network error handling
        NetworkErrorEvent = args.NetworkErrorEvent;
        ErrorHandlingInterceptor.OnErrorAction = OnNetworkError;

        // Setup asset systems
        DarkOctoSetupper.StartSetup(!OctoManager.IsSetupped, true);

        // Setup networking systems
        NetworkConfig networkConfig = new();
        new NetworkInitializer().Initialize(networkConfig);
        KernelState.NetworkConfig = networkConfig;

        // Generate various system instances
        Generator.OnEntrypoint();

        // Initialize global user preferences and information
        PlayerPreference.Instance.Initialize();

        // Setup asset management
        OctoManager.StartDbUpdate(null, args.ShouldReset, args.AssetDbRevision);

        IsSetup = true;
    }

    private static async Task LoginAsync(ApplicationInitArguments args)
    {
        if (!args.ShouldLogin || IsLoggedIn) return;

        IAuthenticationProvider authProvider = new BaseAuthenticationProvider();

        // Get auth URL
        AuthenticationUrlResult authUrlResult = await authProvider.GetAuthenticationUrlAsync();

        if (!authUrlResult.Success)
        {
            throw new ApiException("Failed to generate login URL");
        }

        Console.WriteLine();
        Console.WriteLine($"Login to your account at: {authUrlResult.Url}");
        Console.WriteLine("Once you login and confirm transfer, press ENTER to continue");

        TransferUserResult transferResult;
        do
        {
            Console.ReadLine();
            transferResult = await authProvider.TransferUserAsync(authUrlResult.Uuid);
        } while (!transferResult.Success);

        // Set user information obtained after login
        PlayerRegistration activePlayer = new(authUrlResult.Uuid)
        {
            UserId = transferResult.UserId,
            Signature = transferResult.Signature,
            ServerAddressAndPort = Config.Api.Hostname + Config.Api.Port
        };

        PlayerPreference.Instance.ActivePlayer = activePlayer;

        // Initialize globally accessible user info
        ApplicationScopeClientContext.Instance.User = new UserInfo(activePlayer);
    }

    private static async Task SetupMasterAndUserDataAsync(ApplicationInitArguments args)
    {
        if (args.ShouldAuthorize && !IsAuthorized)
        {
            // Set logged in user globally
            var activePlayer = PlayerPreference.Instance.ActivePlayer ?? throw new ApiException("Cannot authorize user, no user is logged in");
            ApplicationScopeClientContext.Instance.User = new UserInfo(activePlayer);

            // Authorize user on API
            await AuthorizeUserAsync(activePlayer.UserId);

            // Update master and user data
            await UpdateMasterDataAsync();
            await UpdateUserDataAsync();

            // Update user preferences
            UpdateUserPreferences(activePlayer.UserId);

            IsAuthorized = true;
        }

        IsInitialized = true;
    }

    internal static async Task AuthorizeUserAsync(long userId)
    {
        // Execute authorization
        await UserAuthComposite.UserAuth(ContextApi.ActiveContext.Thread.Source.Token);

        // Reset UserId after authorization
        // HINT: UserId in AuthUserResponse is always 0, but it's unknown where it gets reset to the previous, valid UserId
        ApplicationScopeClientContext.Instance.User.UserId = userId;
        PlayerPreference.Instance.ActivePlayer.UserId = userId;
        CalculatorNetworking.SetupAuthUpdateUserState(userId, ApplicationScopeClientContext.Instance.User.Signature);
    }

    private static async Task UpdateMasterDataAsync()
    {
        var result = await MasterDataDownloader.DownloadAsync(ContextApi.ActiveContext.Thread.Source.Token);

        if (result != 0)
        {
            throw new ApiException("Failed to update master data");
        }
    }

    private static async Task UpdateUserDataAsync()
    {
        UserDataGet userDataGet = new();
        bool success = false;
        for (int i = 0; i < RetryCount; i++)
        {
            success = await userDataGet.RequestAsync();
            if (success) break;
        }

        if (!success)
        {
            throw new ApiException($"Failed to update user data: {LastNetworkError.Message}");
        }
    }

    private static void UpdateUserPreferences(long userId)
    {
        var entityIUser = DatabaseDefine.User.EntityIUserTable.FindByUserId(userId);

        // Update playerId in user preferences
        var activePlayer = PlayerPreference.Instance.ActivePlayer;
        activePlayer.PlayerId = entityIUser.PlayerId;

        PlayerPreference.Instance.ActivePlayer.PlayerId = entityIUser.PlayerId;

        // Set globally accessible user instances
        PlayerPreference.Instance.ActivePlayer = activePlayer;
        ApplicationScopeClientContext.Instance.User = new UserInfo(activePlayer);

        // Persist preferences
        PlayerPrefs.Instance.Save();
    }

    private static async Task<bool> OnNetworkError(RpcException e)
    {
        var result = false;
        if (NetworkErrorEvent != null)
            result = await NetworkErrorEvent(e);

        LastNetworkError = e;

        return result;
    }

    internal static void ClearLastNetworkError()
    {
        LastNetworkError = null;
    }
}

public record ApplicationInitArguments(bool ShouldLogin, bool ShouldAuthorize, bool ShouldReset, int AssetDbRevision = 0, Func<RpcException, Task<bool>> NetworkErrorEvent = null);
