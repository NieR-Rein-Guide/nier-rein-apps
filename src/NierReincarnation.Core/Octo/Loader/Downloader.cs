using NierReincarnation.Core.Octo.Network;
using System.Net;

namespace NierReincarnation.Core.Octo.Loader;

internal sealed class Downloader : BaseExecutor
{
    public IDownloadRequest Request(string url, WebHeaderCollection headers, byte[] requestData,
        Action<byte[], Error> onComplete, Action<ulong, ulong> onProgress, bool immediate = false)
    {
        // Note: Completely custom logic to just execute the request here
        using HttpClient client = new();
        HttpRequestMessage req = new(HttpMethod.Get, url);

        foreach (var headerName in headers.AllKeys)
        {
            req.Headers.Add(headerName, headers[headerName]);
        }

        if (requestData?.Length > 0)
        {
            req.Content = new ByteArrayContent(requestData);
        }

        var res = client.Send(req);
        var error = (Error)null;
        if (!res.IsSuccessStatusCode)
        {
            error = new Error("error.message", res.ReasonPhrase);
        }

        onComplete?.Invoke(res.Content.ReadAsByteArrayAsync().Result, error);

        return new DownloadRequest();
    }
}

// Note: DownloadRequest implementation as stub for Unity
internal class DownloadRequest : IDownloadRequest
{
    private string _name;

    public void SetName(string name)
    {
        _name = name;
    }
}
