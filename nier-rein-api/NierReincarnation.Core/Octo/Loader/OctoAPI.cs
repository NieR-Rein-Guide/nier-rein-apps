using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Network;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo.Loader
{
    internal sealed class OctoAPI
    {
        private static readonly string Tag = "Octo/API"; // 0x0
        private static readonly string ApiList = "v1/list"; // 0x8
        private static readonly string AesApiListFormat = "v2/pub/a/{0}/v/{1}/list"; // 0x10
        private static readonly string ApiRevision = "v1/revision"; // 0x18
        private static readonly string ApiErrorReport = "v1/er"; // 0x20
        internal static readonly string HeaderOctoKey = "X-OCTO-KEY"; // 0x28
        private static readonly int UrlCapacity = 256; // 0x30

        private readonly StringBuilder _urlBuilder; // 0x10
        private readonly int _urlBaseLength; // 0x18
        private readonly int _version; // 0x1C
        private readonly WebHeaderCollection _headers; // 0x20
        private readonly string _errorReportUrl; // 0x28
        private readonly string _aesListUrl; // 0x30
        private readonly AESCrypt _crypt; // 0x38
        //private ErrorReport errorReport; // 0x40

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

            var key = SHA256.Create().ComputeHash(Bytes.StringToByteArray(settings.A));
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

                if (bytes != null && bytes.Length > 0)
                {
                    onComplete(bytes, error);
                    return;
                }

                // Log error with logger at OctoManager+0x18 and message 'Octo server returned empty data'
                error = CreateEmptyDataError();
                onComplete(bytes, error);
            });
        }

        private void GetList(int revision, Action<byte[], Error> onComplete)
        {
            if (GetListAes(revision, onComplete))
                return;

            var apiUrl = CreateUrl(ApiList, new[] { $"{_version}", $"{revision}" });
            var req = ExecuteRequest(apiUrl, _headers, null, onComplete);

            req.SetName(Tag);
        }

        private bool GetListAes(int revision, Action<byte[], Error> onComplete)
        {
            if (_crypt == null)
                return false;

            var url = CreateUrl(_aesListUrl, new[] { $"{revision}" });
            var req = ExecuteRequest(url, _headers, null, (bytes, error) =>
            {
                if (error != null || bytes == null)
                    throw new ArgumentNullException();

                var dec = DecryptAes(bytes);
                onComplete(dec, error);
            });

            req.SetName(Tag);
            return true;
        }

        private string CreateUrl(string endpoint, string[] args)
        {
            _urlBuilder.Length = _urlBaseLength;
            _urlBuilder.Append(endpoint);

            if (args == null || args.Length <= 0)
                throw new ArgumentNullException();

            var isQuery = false;
            foreach (var arg in args)
            {
                if (string.IsNullOrEmpty(arg))
                    continue;

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

        public byte[] DecryptAes(byte[] bytes)
        {
            if (_crypt == null)
                return bytes;

            var iv = new byte[0x10];
            Array.Copy(bytes, iv, iv.Length);
            _crypt.UpdateIV(iv);

            var ms = new MemoryStream(bytes, 0x10, bytes.Length - 0x10);
            return _crypt.Decrypt(ms);
        }

        private static Error CreateEmptyDataError()
        {
            return new Error("octo.network.unknown_reason", "Octo server returned empty data");
        }
    }
}
