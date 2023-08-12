using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Network;
using NierReincarnation.Core.Octo.Util;
using System.Net;
using System.Security.Cryptography;

namespace NierReincarnation.Core.Octo.Loader;

internal sealed class OctoAPI
{
    private const string Tag = "Octo/API";
    private const string ApiList = "v1/list";
    private const string AesApiListFormat = "v2/pub/a/{0}/v/{1}/list";
    private const string ApiRevision = "v1/revision";
    private const string ApiErrorReport = "v1/er";
    internal static readonly string HeaderOctoKey = "X-OCTO-KEY";
    private const int UrlCapacity = 256;

    private readonly StringBuilder _urlBuilder;
    private readonly int _urlBaseLength;
    private readonly int _version;
    private readonly WebHeaderCollection _headers;
    private readonly string _aesListUrl;
    private readonly AESCrypt _crypt;

    public OctoAPI(IOctoSettings settings)
    {
        _urlBuilder = new StringBuilder(UrlCapacity);
        _urlBuilder.Append(settings.Url);
        if (!settings.Url.EndsWith('/'))
            _urlBuilder.Append('/');

        _urlBaseLength = _urlBuilder.Length;
        _version = settings.Version;

        _headers = new WebHeaderCollection
        {
            ["Accept"] = $"application/x-protobuf,x-octo-app/{settings.AppId}"
        };

        if (!string.IsNullOrEmpty(settings.ClientSecretKey))
            _headers[HeaderOctoKey] = settings.ClientSecretKey;

        _aesListUrl = string.Format(AesApiListFormat, settings.AppId, settings.Version);

        var key = SHA256.HashData(Bytes.StringToByteArray(settings.A));
        _crypt = new AESCrypt(key);
    }

    public void GetDatabaseDiff(int revision, Action<byte[], Error> onComplete)
    {
        GetList(revision, (bytes, error) =>
        {
            if (error != null)
            {
                onComplete(bytes, error);
                return;
            }

            if (bytes?.Length > 0)
            {
                onComplete(bytes, error);
                return;
            }

            error = CreateEmptyDataError();
            onComplete(bytes, error);
        });
    }

    private void GetList(int revision, Action<byte[], Error> onComplete)
    {
        if (GetListAes(revision, onComplete)) return;

        var apiUrl = CreateUrl(ApiList, new[] { $"{_version}", $"{revision}" });
        var req = ExecuteRequest(apiUrl, _headers, null, onComplete);

        req.SetName(Tag);
    }

    private bool GetListAes(int revision, Action<byte[], Error> onComplete)
    {
        if (_crypt == null) return false;

        var url = CreateUrl(_aesListUrl, new[] { $"{revision}" });
        var req = ExecuteRequest(url, _headers, null, (bytes, error) =>
        {
            if (error != null || bytes == null)
            {
                throw new ArgumentNullException();
            }

            var dec = DecryptAes(bytes);
            onComplete(dec, error);
        });

        req.SetName(Tag);
        return true;
    }

    public byte[] DecryptAes(byte[] bytes)
    {
        if (_crypt == null)
        {
            return bytes;
        }

        byte[] iv = new byte[0x10];
        Array.Copy(bytes, iv, iv.Length);
        _crypt.UpdateIV(iv);

        MemoryStream ms = new(bytes, 0x10, bytes.Length - 0x10);
        return _crypt.Decrypt(ms);
    }

    private string CreateUrl(string endpoint, string[] args)
    {
        _urlBuilder.Length = _urlBaseLength;
        _urlBuilder.Append(endpoint);

        if (args == null || args.Length == 0)
        {
            throw new ArgumentNullException();
        }

        var isQuery = false;
        foreach (var arg in args)
        {
            if (string.IsNullOrEmpty(arg)) continue;

            if (arg[0] != '?')
            {
                _urlBuilder.Append(isQuery ? '&' : '/');
                _urlBuilder.Append(arg);
            }
            else
            {
                _urlBuilder.Append(arg);
                isQuery = true;
            }
        }

        return _urlBuilder.ToString();
    }

    private static IDownloadRequest ExecuteRequest(string url, WebHeaderCollection header, byte[] requestData,
        Action<byte[], Error> onComplete)
    {
        return OctoManager.Internal._downloader.Request(url, header, requestData, onComplete, null, true);
    }

    private static Error CreateEmptyDataError()
    {
        return new Error("octo.network.unknown_reason", "Octo server returned empty data");
    }
}
