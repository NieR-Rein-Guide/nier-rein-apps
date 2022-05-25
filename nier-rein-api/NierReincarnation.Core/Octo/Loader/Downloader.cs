using System;
using System.Net;
using System.Net.Http;
using NierReincarnation.Core.Octo.Network;

namespace NierReincarnation.Core.Octo.Loader
{
    class Downloader : BaseExecutor
    {
        public IDownloadRequest Request(string url, WebHeaderCollection headers, byte[] requestData,
            Action<byte[], Error> onComplete, Action<ulong, ulong> onProgress, bool immediate = false)
        {
            // CUSTOM: Completely custom logic to just execute the request here
            var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Get, url);

            foreach (var headerName in headers.AllKeys)
                req.Headers.Add(headerName, headers[headerName]);

            if (requestData != null && requestData.Length > 0)
                req.Content = new ByteArrayContent(requestData);

            var res = client.Send(req);
            var error = (Error)null;
            if (!res.IsSuccessStatusCode)
                error = new Error("error.message", res.ReasonPhrase);

            onComplete?.Invoke(res.Content.ReadAsByteArrayAsync().Result, error);

            return new DownloadRequest();
        }
    }

    // CUSTOM: DownloadRequest implementation as stub for Unity
    class DownloadRequest : IDownloadRequest
    {
        private string _name;

        public void SetName(string name)
        {
            _name = name;
        }
    }
}
