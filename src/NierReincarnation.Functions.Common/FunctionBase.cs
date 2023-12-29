using Microsoft.Extensions.Logging;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Proto;
using NierReincarnation.Core.UnityEngine;
using ProtoBuf;
using System.Security.Cryptography;
using System.Text;

namespace NierReincarnation.Functions.Common;

public abstract class FunctionBase
{
    protected static async Task<Database?> GetDatabaseAsync(HttpClient _httpClient, ILogger _logger, int revision)
    {
        OctoFullSettings octoSettings = DarkOctoSetupper.CreateSetting();
        AESCrypt crypt = new(SHA256.HashData(Encoding.UTF8.GetBytes(octoSettings.A)));

        // Send request
        HttpRequestMessage req = new(HttpMethod.Get, Config.Octo.Url + $"v2/pub/a/{octoSettings.AppId}/v/{octoSettings.Version}/list/{revision}");
        req.Headers.Add("Accept", $"application/x-protobuf,x-octo-app/{octoSettings.AppId}");
        req.Headers.Add("X-OCTO-KEY", $"{octoSettings.ClientSecretKey}");
        HttpResponseMessage res = await _httpClient.SendAsync(req);

        // Handle response
        if (!res.IsSuccessStatusCode)
        {
            _logger.LogError($"Error while fetching {Application.SystemRegion} asset list: {res.ReasonPhrase} - {res.StatusCode}");
            return default;
        }

        byte[] bytes = await res.Content.ReadAsByteArrayAsync();
        bytes = DecryptAes(crypt, bytes);

        await using MemoryStream memoryStream = new(bytes);
        return Serializer.Deserialize<Database>(memoryStream);
    }

    private static byte[] DecryptAes(AESCrypt crypt, byte[] bytes)
    {
        byte[] iv = new byte[0x10];
        Array.Copy(bytes, iv, iv.Length);
        crypt.UpdateIV(iv);

        using MemoryStream ms = new(bytes, 0x10, bytes.Length - 0x10);
        return crypt.Decrypt(ms);
    }
}
