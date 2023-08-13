using Google.Protobuf.WellKnownTypes;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Art.Framework.ApiNetwork;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.UnityEngine;
using MD5 = System.Security.Cryptography.MD5;

namespace NierReincarnation.Core.Art.Library.Masterdata.Download;

public class MasterDataDownloader
{
    public static Func<int> MasterDataVersionGetter { get; set; }

    public static Action<int> MasterDataVersionSetter { get; set; }

    public static Func<byte[], byte[]> Decrypt;

    private const int SplitCount = 10;

    private const int RetryCount = 3;

    private const int Timeout = 10;

    private const int InvalidSize = 0;

    private const int InvalidUpdateCount = 0;

    private const string HttpContentLength = "Content-Length";

    private const string HttpResponseHeaderAcceptRange = "Accept-Ranges";

    private const string HttpResponseHeaderAcceptRangeValue = "bytes";

    private const string HttpRangeHeader = "Range";

    private const int MasterCachePathContentSize = 10;

    private const int ContentLengthDownloadTimeout = 30;

    private const long HttpResponseCodePartialContent = 206;

    public static async Task<int> DownloadAsync(CancellationToken cancellationToken)
    {
        // This client will set with default values, since no master data can retrieve requested information yet
        var dataService = new DarkClient().DataService;
        var versionResponse = await dataService.GetLatestMasterDataVersionAsync(new Empty());
        if (versionResponse == null)
            return InvalidSize;

        ApiSystem.Instance.Parameter?.MasterDataVersion?.UpdateMasterDataHash(versionResponse.LatestMasterDataVersion);
        ApplicationScopeClientContext.Instance.MasterData?.UpdateMasterDataHash(versionResponse.LatestMasterDataVersion);

        var masterDataUrl = Config.Api.MakeMasterDataUrl(versionResponse.LatestMasterDataVersion);
        var masterContentLength = await GetMasterDataContentLength(masterDataUrl, cancellationToken);
        var masterDataCache = await TryGetMasterDataCacheAsync(versionResponse.LatestMasterDataVersion, masterContentLength.Item1, masterContentLength.Item3);

        var masterData = masterDataCache.Item2;
        if (!masterDataCache.Item1)
        {
            masterData = await DownloadData(masterDataUrl, SplitCount, masterContentLength.Item1, masterContentLength.Item2, cancellationToken);
            if (masterData == null)
            {
                return InvalidUpdateCount;
            }
        }

        var decMasterData = Decrypt?.Invoke(masterData);
        DatabaseDefine.Master = new DarkMasterMemoryDatabase(decMasterData);

        if (!masterDataCache.Item1)
        {
            await WriteMasterDataCacheAsync(versionResponse.LatestMasterDataVersion, masterData);
        }

        DeviceUtil.DeviceUtil.SetMdcs(versionResponse.LatestMasterDataVersion, CalculateChecksum(masterData));

        return 0;
    }

    private static async Task<byte[]> DownloadData(string url, int splitCount, int contentLength,
        bool withPartialDownload, CancellationToken cancellationToken)
    {
        byte[] result = new byte[contentLength];
        splitCount = withPartialDownload ? splitCount : 1;

        var ranges = CalculateSplitDataRanges(splitCount, contentLength);
        var resultIndex = 0;
        foreach (var range in ranges)
        {
            var downloadRangeResult = await DownloadRangeData(url, range, cancellationToken);
            Array.Copy(downloadRangeResult.Item1, 0, result, resultIndex, downloadRangeResult.Item1.Length);

            resultIndex += downloadRangeResult.Item1.Length;
        }

        return result;
    }

    private static async Task<(byte[], bool)> DownloadRangeData(string url, Range range, CancellationToken cancellationToken)
    {
        var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(ContentLengthDownloadTimeout) };

        var req = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
        req.Headers.Add(HttpRangeHeader, GetRangeHeaderValue(range));

        // Get split data
        var res = await httpClient.SendAsync(req, cancellationToken);
        if (!res.IsSuccessStatusCode) return default;

        MemoryStream data = new();
        await res.Content.CopyToAsync(data, cancellationToken);

        return (data.ToArray(), HttpResponseCodePartialContent == (int)res.StatusCode);
    }

    private static async Task<(int, bool, byte[])> GetMasterDataContentLength(string masterDataUrl, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = new() { Timeout = TimeSpan.FromSeconds(ContentLengthDownloadTimeout) };

        // Get content length
        HttpRequestMessage req = new(HttpMethod.Head, new Uri(masterDataUrl));
        var res = await httpClient.SendAsync(req, cancellationToken);
        if (!res.IsSuccessStatusCode) return (InvalidSize, false, null);

        var contentLengthValue = res.Content.Headers.GetValues(HttpContentLength).FirstOrDefault();
        if (!int.TryParse(contentLengthValue, out var contentLength)) return (InvalidSize, false, null);

        // Get content
        req = new HttpRequestMessage(HttpMethod.Get, new Uri(masterDataUrl));
        req.Headers.Add(HttpRangeHeader, GetRangeHeaderValue(new Range(0, MasterCachePathContentSize)));
        res = await httpClient.SendAsync(req, cancellationToken);
        if (!res.IsSuccessStatusCode) return (InvalidSize, false, null);

        var acceptRangeHeader = res.Headers.GetValues(HttpResponseHeaderAcceptRange).FirstOrDefault();

        MemoryStream data = new();
        await res.Content.CopyToAsync(data, cancellationToken);

        return (contentLength, acceptRangeHeader == HttpResponseHeaderAcceptRangeValue, data.ToArray());
    }

    private static async Task<(bool, byte[])> TryGetMasterDataCacheAsync(string version, int contentLength, byte[] headContent)
    {
        var cachePath = GetMasterDataCachePath(version, headContent);
        if (!File.Exists(cachePath))
            return default;

        // Read cache if it exists
        await using var cacheFile = File.OpenRead(cachePath);
        byte[] cacheData = new byte[cacheFile.Length];
        await cacheFile.ReadAsync(cacheData);

        if (cacheData.Length != contentLength)
        {
            return default;
        }

        return (true, cacheData);
    }

    private static string GetMasterDataCachePath(string version, byte[] headContent)
    {
        var versionArray = Encoding.UTF8.GetBytes(version);
        var result = new byte[versionArray.Length + headContent.Length];

        Array.Copy(versionArray, result, versionArray.Length);
        Array.Copy(headContent, 0, result, versionArray.Length, headContent.Length);

        var tempCachePath = Path.Combine(Application.PersistentDataPath, "cache");
        Directory.CreateDirectory(tempCachePath);

        return tempCachePath + "/mst-" + CalculateChecksum(result);
    }

    private static string CalculateChecksum(byte[] data)
    {
        byte[] hash = MD5.HashData(data);

        return Convert.ToHexString(hash);
    }

    private static string GetRangeHeaderValue(Range rangeContentSize) => $"bytes={rangeContentSize.Start.Value}-{rangeContentSize.End.Value - 1}";

    private static async Task WriteMasterDataCacheAsync(string version, byte[] data)
    {
        var path = GetMasterDataCachePath(version, data.Take(MasterCachePathContentSize).ToArray());

        await using FileStream cacheStream = new(path, FileMode.OpenOrCreate, FileAccess.Write);
        await cacheStream.WriteAsync(data);
    }

    private static Range[] CalculateSplitDataRanges(int count, int contentLength)
    {
        var bytesPerSplit = count != 0 ? contentLength / count : 0;

        // Split data range in equal splits
        var result = new Range[count];
        for (var i = 0; i < count; i++)
        {
            result[i] = new Range(i * bytesPerSplit, (i * bytesPerSplit) + bytesPerSplit);
        }

        // Make last split large enough to fit remaining data
        if (result[^1].End.Value != contentLength)
        {
            result[^1] = new Range(result[^1].Start, contentLength);
        }

        return result;
    }
}
