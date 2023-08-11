using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Context.Support;

static class WebApiSupport
{
    public static HttpRequestMessage CreateRequest(HttpMethod method, Uri uri)
    {
        var request = new HttpRequestMessage(method, uri) { Version = new Version(2, 0) };

        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Add("Origin", "https://web.app.nierreincarnation.com");
        request.Headers.Add("x-requested-with", Application.Identifier);

        AddUserAgents(request);

        return request;
    }

    private static void AddUserAgents(HttpRequestMessage request)
    {
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("(Linux; Android 7.1.1; ONEPLUS A3010 Build/NMF26F; wv)"));
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("AppleWebKit", "537.36"));
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("(KHTML, like Gecko)"));
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Version", "4.0"));
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Chrome", "78.0.3904.108"));
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Safari", "537.36"));
    }
}
