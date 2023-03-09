using Grpc.Core;
using NierReincarnation.Context;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Adam.Framework.Network.Interceptors;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Art.Library.Masterdata.Download;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Dark.Kernel;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.Networking.DataSource.User;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Localizations;
using System;
using System.IO;
using System.Threading.Tasks;
using Config = NierReincarnation.Core.Dark.EntryPoint.Config;

namespace NierReincarnation
{
    /// <summary>
    /// HINT: The whole class is static to go with the singleton nature of the application. Doing an instance-based approach at this stage would
    ///       require a rewrite of the fundamental code, to never use singleton instances.
    /// </summary>
    public static class NierReincarnation
    {
        private const int RetryCount_ = 3;
        private const string DefaultResourceRoot_ = "./resources";

        public static NotificationContext Notifications { get; } = new NotificationContext();

        public static AssetContext Assets { get; } = new AssetContext();

        public static bool IsInitialized { get; private set; }

        public static bool IsSetup { get; private set; }

        public static event Func<RpcException, Task<bool>> ApiError;
        public static RpcException LastApiError { get; private set; }

        static NierReincarnation()
        {
            SetResourceRootPath(DefaultResourceRoot_);

            Generator.OnEntrypoint();

            DarkOctoSetupper.StartSetup(!OctoManager.IsSetupped, true);
        }

        public static NierReinContexts GetContexts()
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Initialize the application first before accessing its functions.");

            return new NierReinContexts();
        }

        public static void SetResourceRootPath(string rootPath)
        {
            if (IsSetup)
                throw new InvalidOperationException("Resource root path cannot be changed after setting up the application.");

            // Ensure that the resource path exists
            Directory.CreateDirectory(rootPath);

            // Setup root path for resources
            Application.SetRoot(rootPath);
        }

        /// <summary>
        /// Sets up and initializes the application with a user for direct use on the command line.
        /// </summary>
        /// <param name="username">The user to log in with. Will only be used if a user is not already present.</param>
        /// <param name="password">The password of the user. Will only be used if a user is not already present.</param>
        /// <param name="otpCallback">A callback to receive the OTP for logging.</param>
        /// <param name="isLogin">True if the user should be logged in, otherwise false</param>
        /// <param name="isReset">True if the Master database should be reset, otherwise false</param>
        /// <param name="dbRevision">The revision to reset the Master database to</param>
        /// <returns><see cref="Task"/> representing the setup operation.</returns>
        public static async Task PrepareCommandLine(string username, string password, Func<Task<string>> otpCallback = null,
            bool isLogin = true, bool isReset = false, int dbRevision = 0)
        {
            Setup(isReset, dbRevision);

            if (isLogin && !IsLoggedIn())
            {
                if (string.IsNullOrEmpty(username))
                    throw new InvalidOperationException("A username is required for an initial login.");
                if (string.IsNullOrEmpty(password))
                    throw new InvalidOperationException("A password is required for an initial login.");

                var isLoggedIn = await Login(username, password, otpCallback);
                if (!isLoggedIn)
                    return;
            }

            await Initialize(isLogin);
        }

        public static void Setup(bool isReset = false, int dbRevision = 0)
        {
            if (IsSetup)
                return;

            // Set network error handler
            ErrorHandlingInterceptor.OnErrorAction = OnNetworkError;

            // Initialize asset system
            // HINT: Call taken from Adam.Framework.Resource.AssetBundleLookupTableOctoDatabase$$Initialize until further investigation into asset management
            Console.WriteLine("Setup asset management system.");
            DarkOctoSetupper.StartSetup(!OctoManager.IsSetupped, true);

            // Initialize global network system
            InitializeNetwork();

            // Generate various system instances
            Generator.OnEntrypoint();

            // Initialize global user preferences and information
            Console.WriteLine("Initialize player preferences.");
            PlayerPreference.Instance.Initialize();

            // Setup asset management
            Console.WriteLine("Perform asset database update.");
            OctoManager.StartDbUpdate(null, isReset, dbRevision);

            IsSetup = true;
        }

        public static bool IsLoggedIn()
        {
            return PlayerPrefs.Exists;
        }

        public static async Task<bool> Login(string username, string password, Func<Task<string>> otpCallback = null)
        {
            // Setup application instances
            if (!IsSetup)
                Setup();

            // Login user
            return await LoginUser(username, password, otpCallback);
        }

        /// <summary>
        /// Sets up and initializes the application systems.
        /// </summary>
        /// <returns></returns>
        public static async Task Initialize(bool isLogin = true)
        {
            if (IsInitialized)
                return;

            // Setup application instances
            if (!IsSetup)
                Setup();

            // Initialize remaining system and data
            await InitializeCore(isLogin);
        }

        public static async Task LoadLocalizations(Language lang)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Initialize the application first before accessing its functions.");

            // Update text assets and load localizations
            AssetContext assetContext = new();
            await assetContext.DownloadTextAssets(lang);

            switch (lang)
            {
                case Language.English:
                    // TODO: A text file with japanese text in english assets that is always preferred. Remove it manually for now
                    // TODO: Naming consistency between ) and / in asset methods
                    assetContext.RemoveAsset("text/en/ui/ui_0150350.asset");
                    break;
            }

            LocalizationExtensions.Localizations = Localizer.Create();
        }

        private static async Task InitializeCore(bool isLogin = true)
        {
            if (isLogin)
            {
                // If no active player is stored in preferences, log in user with credentials
                var activePlayer = PlayerPreference.Instance.ActivePlayer ?? throw new InvalidOperationException("No user is logged in.");

                // Set logged in user globally
                ApplicationScopeClientContext.Instance.User = new ApplicationScopeClientContext.UserInfo(activePlayer);

                // Authorize user on API
                await AuthorizeUser(activePlayer.UserId);

                // Update master data
                var isMasterSuccess = await UpdateMasterData();
                if (!isMasterSuccess)
                    return;

                // Update user data
                var isUserSuccess = await UpdateUserData();
                if (!isUserSuccess)
                    return;

                // Update user preferences with current user data from API
                UpdateUserPreferences(DatabaseDefine.User.EntityIUserTable.FindByUserId(activePlayer.UserId));
            }

            IsInitialized = true;
        }

        private static async Task<bool> LoginUser(string username, string password, Func<Task<string>> otpCallback)
        {
            // Login with SquareEnix-Bridge account
            Console.WriteLine($"Login user '{username}'.");
            var (uuid, userId, signature) = await Auth.LoginSquareEnixBridge(username, password, otpCallback);
            if (uuid == null)
                return false;

            // Set user information obtained after login
            SetUser(uuid, userId, signature);

            return true;
        }

        private static void SetUser(string uuid, long userId, string signature)
        {
            // Set user to local player preferences
            var activePlayer = new PlayerRegistration(uuid)
            {
                UserId = userId,
                Signature = signature,
                ServerAddressAndPort = Config.Api.GetHostname() + Config.Api.Port
            };

            PlayerPreference.Instance.ActivePlayer = activePlayer;

            // Initialize globally accessible user info
            ApplicationScopeClientContext.Instance.User = new ApplicationScopeClientContext.UserInfo(activePlayer);
        }

        private static void InitializeNetwork()
        {
            var networkConfig = new NetworkConfig();
            new NetworkInitializer().Initialize(networkConfig);
            KernelState.NetworkConfig = networkConfig;
        }

        internal static async Task AuthorizeUser(long userId)
        {
            // Execute authorization
            Console.WriteLine("Authorize user on game API.");
            await UserAuthComposite.UserAuth(ContextApi.ActiveContext.Thread.Source.Token);

            // Reset UserId after authorization
            // HINT: UserId in AuthUserResponse is always 0, but it's unknown where it gets reset to the previous, valid UserId
            ApplicationScopeClientContext.Instance.User.UserId = userId;
            PlayerPreference.Instance.ActivePlayer.UserId = userId;

            CalculatorNetworking.SetupAuthUpdateUserState(userId, ApplicationScopeClientContext.Instance.User.Signature);
        }

        private static async Task<bool> UpdateMasterData()
        {
            Console.WriteLine("Update master data.");
            var result = await MasterDataDownloader.DownloadAsync(ContextApi.ActiveContext.Thread.Source.Token);

            return result == 0;
        }

        internal static async Task<bool> UpdateUserData()
        {
            Console.WriteLine("Update user data.");

            var userDataGet = new UserDataGet();
            for (var i = 0; i < RetryCount_; i++)
            {
                var wasSuccessful = await userDataGet.RequestAsync();
                if (wasSuccessful)
                    return true;

                Console.WriteLine($"User data error: {LastApiError.Message}");
                if (i + 1 < RetryCount_)
                    Console.WriteLine("Retry user data.");
            }

            Console.WriteLine("Couldn't retrieve user data.");
            return false;
        }

        private static void UpdateUserPreferences(EntityIUser user)
        {
            // Update playerId in user preferences
            var activePlayer = PlayerPreference.Instance.ActivePlayer;
            activePlayer.PlayerId = user.PlayerId;

            // Set globally accessible user instances
            PlayerPreference.Instance.ActivePlayer = activePlayer;
            ApplicationScopeClientContext.Instance.User = new ApplicationScopeClientContext.UserInfo(activePlayer);

            // Persist preferences
            PlayerPrefs.Instance.Save();
        }

        private static async Task<bool> OnNetworkError(RpcException e)
        {
            var result = false;
            if (ApiError != null)
                result = await ApiError(e);

            LastApiError = e;

            return result;
        }

        internal static void ClearNetworkError()
        {
            LastApiError = null;
        }

        public static void Reset()
        {
            IsSetup = false;
            IsInitialized = false;
        }
    }
}
