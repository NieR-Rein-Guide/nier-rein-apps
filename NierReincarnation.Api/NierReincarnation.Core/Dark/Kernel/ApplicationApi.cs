using System;
using NierReincarnation.Core.Dark.Component.OctoInfo;

namespace NierReincarnation.Core.Dark.Kernel;

// Dark.Kernel.ApplicationApi
public static class ApplicationApi
{
   
    private static readonly string UnregistUserName = "Un-regist User Name";
   
    public static readonly string kEntrypointSceneName = "dark_gameplay";

    public static void Run()
    {
        ContextApi.ActivateContext(ContextApi.CreateContext());

        SetupApplication();
        Thread.SetupThread();

        // [...] Skip unnecessary instantiation

        if (ValidGameplayScene())
            StateMachine.SetupFirstStateMachines();
    }

    public static void SetupApplication()
    {
        //ContextApi.ActiveContext.Application.PerformanceConfig = new PerformanceConfig();
        //ContextApi.ActiveContext.Application.TransitionState = new ApplicationTransitionState();
        ContextApi.ActiveContext.Application.OctoInfo = new OctoInfo();
        //ContextApi.ActiveContext.Application.ViewConfig = new ViewConfig();

        //ContextApi.ActiveContext.Application.ViewConfig.LoadDefaultViewConfigLanguage();
    }

    public static void SetReviewServerInfo(string serverAddress, int serverPort)
    {
        ContextApi.ActiveContext.Application.ReviewServerAddress = serverAddress;
        ContextApi.ActiveContext.Application.ReviewServerPort = serverPort;
    }

    public static bool IsReviewEnvironment()
    {
        if (ContextApi.ActiveContext?.Application?.OctoInfo == null)
            throw new InvalidOperationException("OctoInfo is not set.");

        return ContextApi.ActiveContext.Application.OctoInfo.IsReviewEnvironment;
    }

    public static string GetReviewUrlFormat()
    {
        return ContextApi.ActiveContext.Application.ReviewUrlFormat;
    }

    public static string GetReviewWebViewBaseUrl()
    {
        return ContextApi.ActiveContext.Application.ReviewWebViewBaseUrl;
    }

    public static int GetReviewEnvironmentOctoAppId()
    {
        return ContextApi.ActiveContext.Application.OctoInfo.AppId;
    }

    public static string GetReviewEnvironmentOctoClientSecretKey()
    {
        return ContextApi.ActiveContext.Application.OctoInfo.ClientSecretKey;
    }

    public static string GetReviewEnvironmentOctoAesKey()
    {
        return ContextApi.ActiveContext.Application.OctoInfo.AesKey;
    }

    public static int GetReviewEnvironmentOctoVersion()
    {
        return ContextApi.ActiveContext.Application.OctoInfo.Version;
    }

    public static string GetReviewEnvironmentOctoUrl()
    {
        return ContextApi.ActiveContext.Application.OctoInfo.Url;
    }

    private static bool ValidGameplayScene()
    {
        // HINT: Should check the unity scene manager for a valid scene to be active
        // We're always on a valid scene now
        return true;
    }
}
