using Grpc.Core;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Adam.Framework.Network.Interceptors;
using NierReincarnation.Core.Art.Library.Masterdata.Download;
using NierReincarnation.Core.Custom;
using System.Security.Cryptography;

namespace NierReincarnation.Core.Dark.StateMachine;

// Dark.StateMachine.HandleNet
public class HandleNet
{
    private Aes _aes;

    private Aes _masterAes;

    public HandleNet()
    {
        _aes = Aes.Create();
        _aes.Mode = CipherMode.CBC;
        _aes.Key = Encoding.UTF8.GetBytes("1234567890ABCDEF");
        _aes.IV = Encoding.UTF8.GetBytes("it8bAjktKdFIBYtU");

        _masterAes = Aes.Create();
        _masterAes.Mode = CipherMode.CBC;
        _masterAes.Key = Encoding.UTF8.GetBytes("6Cb01321EE5e6bBe");
        _masterAes.IV = Encoding.UTF8.GetBytes("EfcAef4CAe5f6DaA");
    }

    public static HandleNet Generate()
    {
        var net = new HandleNet();
        net.Initialize();

        return net;
    }

    private void Initialize()
    {
        ErrorHandlingInterceptor.StayError = ShowStayError;
        ErrorHandlingInterceptor.MoveFunctionTopError = ShowMoveFunctionTopError;
        ErrorHandlingInterceptor.MoveTitleError = ShowMoveTitleError;
        ErrorHandlingInterceptor.AuthRetryError = ShowAuthRetryError;
        ErrorHandlingInterceptor.OtherFatalError = ShowOtherFatalError;
        ErrorHandlingInterceptor.RetryErrorDialog = ShowRetryErrorDialog;
        ErrorHandlingInterceptor.MoveTitleMaintenanceError = ShowMoveTitleMaintenanceError;
        ErrorHandlingInterceptor.MoveTitlePermissionDeniedError = ShowMoveTitlePermissionDeniedErrorAsync;
        ErrorHandlingInterceptor.IsPossibleRetry = IsPossibleRetry;
        ErrorHandlingInterceptor.ClientFatalNetWorkError = ShowClientFatalError;

        DarkClient.ClientFatalNetWorkError = ShowClientFatalError;
        DarkClient.OnVerifyToken = OnVerifyToken;

        // CUSTOM: Set delegates for PayloadCallInvoker instead of Grpc.Core.CallOptions
        PayloadCallInvoker.Encrypt = Encrypt;
        PayloadCallInvoker.Decrypt = Decrypt;

        MasterDataDownloader.Decrypt = DecryptMasterData;

        UserDiffUpdateInterceptor.SetGameTimeNow = SetDatetimeNow;
    }

    private byte[] Encrypt(byte[] payload)
    {
        return _aes.CreateEncryptor().TransformFinalBlock(payload, 0, payload.Length);
    }

    private byte[] Decrypt(byte[] receivedMessage)
    {
        return _aes.CreateDecryptor().TransformFinalBlock(receivedMessage, 0, receivedMessage.Length);
    }

    private byte[] DecryptMasterData(byte[] data)
    {
        return _masterAes.CreateDecryptor().TransformFinalBlock(data, 0, data.Length);
    }

    private void SetDatetimeNow(long unixTime)
    {
    }

    private Task ShowStayError(string messageTextId, string messageCode, string errorDetailInfo)
    {
        return Task.CompletedTask;
    }

    private Task ShowMoveFunctionTopError(string messageTextId, string messageCode, string errorDetailInfo,
        long maintenanceDateTime)
    {
        return Task.CompletedTask;
    }

    private Task ShowMoveTitleError(string messageTextId, string messageCode, string errorDetailInfo,
        string maintenanceMessage, long maintenanceDateTime)
    {
        return Task.CompletedTask;
    }

    private Task ShowAuthRetryError()
    {
        return Task.CompletedTask;
    }

    private Task ShowOtherFatalError(StatusCode status, string errorDetailInfo)
    {
        return Task.CompletedTask;
    }

    private Task ShowRetryErrorDialog()
    {
        return Task.CompletedTask;
    }

    private Task ShowMoveTitleMaintenanceError()
    {
        return Task.CompletedTask;
    }

    private Task ShowMoveTitlePermissionDeniedErrorAsync()
    {
        return Task.CompletedTask;
    }

    private bool IsPossibleRetry()
    {
        return false;
    }

    private Task ShowClientFatalError(string errorDetailInfo)
    {
        return Task.CompletedTask;
    }

    private void OnVerifyToken(string methodPath, object request)
    {
    }
}
