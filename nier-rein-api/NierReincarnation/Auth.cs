using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.User;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.UnityEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NierReincarnation
{
    static class Auth
    {
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        private static IDictionary<string, string> _cookies = new Dictionary<string, string>();

        /// <summary>
        /// Returns userId for the credentials given for SquareEnix Bridge.
        /// </summary>
        public static async Task<(string, long, string)> LoginSquareEnixBridge(string username, string password)
        {
            var dc = new DarkClient();

            _cookies.Clear();

            // Get backup token
            var uuid = Guid.NewGuid().ToString();
            var backupTokenRes = await dc.GetBackupTokenAsync(new GetBackupTokenRequest { Uuid = uuid });

            // Use browser
            CallBrowser(backupTokenRes.BackupToken, username, password);

            // Get user id
            var res = await dc.TransferUserAsync(new TransferUserRequest { Uuid = uuid });

            return (uuid, res.UserId, res.Signature);
        }

        private static void CallBrowser(string backupToken, string username, string password)
        {
            // Setup edge driver
            new DriverManager().SetUpDriver(new EdgeConfig());

            // Create a new instance in code
            var options = new EdgeOptions();
            options.AddArgument("headless");
            var driver = new EdgeDriver(options);

            // Execute account choice
            driver.Navigate().GoToUrl($"https://psg.sqex-bridge.jp/ntv/288/update/top?type=2&token={backupToken}");
            driver.FindElement(By.Id("type")).FindElement(By.XPath("./..")).Submit();

            // Execute login
            driver.FindElement(By.Id("sqexid")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Name("login")).Submit();

            // Execute confirmation
            //File.WriteAllText(@"C:\Users\Kirito\source\repos\Grpc_Test\Grpc_Test\bin\Debug\net5.0\resources\data\com.square_enix.android_googleplay.nierspww\shared_prefs\t.html", driver.PageSource);
            var _ = driver.PageSource;
            //var ps1 = driver.PageSource;
            driver.FindElement(By.Name("button")).Click();

            // Close driver
            driver.Quit();
        }

        private static async Task<(string, string)> LoadAccountChoice(string backupToken)
        {
            // Prepare cookies
            _cookies["login_group"] = "2";
            _cookies["_bridge_session"] = Guid.NewGuid().ToString("N");
            _cookies["bridge_session_id_prd"] = Guid.NewGuid().ToString("N");

            // Call /ntv/288/update/top
            var req = CreateRequest(HttpMethod.Get, $"https://psg.sqex-bridge.jp/ntv/288/update/top?type=2&token={backupToken}");
            AddCookies(req, "login_group", "_bridge_session", "bridge_session_id_prd");

            var res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Redirect to /i18n/ntv/288/update/top
            var redirectUri = res.Headers.GetValues("Location").First();

            req = CreateRequest(HttpMethod.Get, redirectUri);
            AddCookies(req, "login_group", "bridge_session_id_prd", "bridge_registration_token", "_bridge_session");

            res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Redirect to /i18n/ntv/288/login/top
            redirectUri = res.Headers.GetValues("Location").First();

            req = CreateRequest(HttpMethod.Get, redirectUri);
            AddCookies(req, "login_group", "bridge_session_id_prd", "_bridge_session", "bridge_registration_token");

            res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Extract terms_id and return it
            var loginContent = await res.Content.ReadAsStringAsync();
            var termsIdRegex = new Regex("id=\"terms_id\" value=\"(.*)\"");
            var termsIdMatch = termsIdRegex.Match(loginContent);

            var termsId = !termsIdMatch.Success ? null : termsIdMatch.Groups[1].Value;
            return (termsId, redirectUri);
        }

        private static async Task<(string, string)> ChooseSquareEnixBridge(string termsId, string loginReferer)
        {
            // Prepare button click point
            var rand = new Random();

            var x = rand.Next(0, 200);
            var y = rand.Next(0, 45);

            // Call to i18n/ntv/288/login/start
            var req = CreateRequest(HttpMethod.Get, $"https://psg.sqex-bridge.jp/i18n/ntv/288/login/start?type=2&lang=en&terms_id={termsId}&x={x}&y={y}");
            req.Headers.Referrer = new Uri(loginReferer);
            AddCookies(req, "login_group", "bridge_session_id_prd", "_bridge_session", "bridge_registration_token", "native_game_id", "native_context", "native_type", "lang");

            var res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Redirect to /oauth/oa/oauthauth
            var redirectUri = res.Headers.GetValues("Location").First();

            req = CreateRequest(HttpMethod.Get, redirectUri);
            req.Headers.Referrer = new Uri("https://psg.sqex-bridge.jp/");

            res = await _client.SendAsync(req);

            // Redirect to /oauth/oa/oauthlogin
            redirectUri = res.Headers.GetValues("Location").First();

            req = CreateRequest(HttpMethod.Get, redirectUri);
            req.Headers.Referrer = new Uri("https://psg.sqex-bridge.jp/");

            res = await _client.SendAsync(req);

            // Extract _STORED_ value
            var loginContent = await res.Content.ReadAsStringAsync();
            var storedRegex = new Regex("name=\"_STORED_\" value=\"(.*)\"");
            var storedMatch = storedRegex.Match(loginContent);

            var storedValue = !storedMatch.Success ? null : storedMatch.Groups[1].Value;
            return (storedValue, redirectUri);
        }

        private static async Task<(string, string)> LoginWithCredentials(string storedValue, string loginReferer, string username, string password)
        {
            // Prepare cookies
            _cookies["_rsid"] = "\"\"";
            _cookies["_si"] = "SIDBZE18";

            // Call to /oauth/oa/oauthlogin.send
            var req = CreateRequest(HttpMethod.Post, "https://secure.square-enix.com/oauth/oa/oauthlogin.send?client_id=bridge_bk&game_id=288&redirect_uri=https%3A%2F%2Fpsg.sqex-bridge.jp%2Fntv%2F288%2Flogin%2Fsqex&response_type=code&alar=1");
            req.Headers.Add("Origin", "https://secure.square-enix.com");
            req.Headers.Referrer = new Uri(loginReferer);
            AddCookies(req, "_rsid", "_si");
            req.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("_STORED_", storedValue),
                new KeyValuePair<string, string>("sqexid", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("wfp", "1")
            });

            var res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Redirect to /oauth/oa/oauthauth
            var redirectUri = res.Headers.GetValues("Location").First();

            req = CreateRequest(HttpMethod.Get, redirectUri);
            req.Headers.Referrer = new Uri(loginReferer);
            AddCookies(req, "_rsid", "_si");

            res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Extract cis_sessid
            var loginContent = await res.Content.ReadAsStringAsync();
            var sessIdRegex = new Regex("name=\"cis_sessid\".*value=\"(.*)\"");
            var sessIdMatch = sessIdRegex.Match(loginContent);

            var sessId = !sessIdMatch.Success ? null : sessIdMatch.Groups[1].Value;

            // Call to /ntv/288/login/sqex (automatic form send from previous call)
            req = CreateRequest(HttpMethod.Post, "https://psg.sqex-bridge.jp/ntv/288/login/sqex");
            req.Headers.Add("Origin", "https://secure.square-enix.com");
            req.Headers.Referrer = new Uri(redirectUri);
            AddCookies(req, "login_group", "bridge_session_id_prd", "bridge_registration_token", "native_game_id", "native_context", "native_type", "lang", "terms_token", "context", "_bridge_session");
            req.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("cis_sessid", sessId),
                new KeyValuePair<string, string>("provision", ""),
                new KeyValuePair<string, string>("_c", "1")
            });

            res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Force call to /i18n/ntv/288/login/execute (skips the terms agreement redirect that might occur in previous call)
            req = CreateRequest(HttpMethod.Get, "https://psg.sqex-bridge.jp/i18n/ntv/288/login/execute?lang=en");
            req.Headers.Referrer = new Uri("https://secure.square-enix.com/");
            AddCookies(req, "login_group", "bridge_session_id_prd", "bridge_registration_token", "native_game_id", "native_context", "native_type", "lang", "terms_token", "_bridge_session", "authToken", "auth_group_id", "channel");

            res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Redirect to i18n/ntv/288/update/execute
            redirectUri = res.Headers.GetValues("Location").First();

            req = CreateRequest(HttpMethod.Get, redirectUri);
            req.Headers.Referrer = new Uri("https://secure.square-enix.com/");
            AddCookies(req, "login_group", "bridge_registration_token", "lang", "terms_token", "_bridge_session", "auth_group_id", "channel", "bridge_session_id_prd", "authToken");

            res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Redirect to /i18n/ntv/288/update/caution
            redirectUri = res.Headers.GetValues("Location").First();

            req = CreateRequest(HttpMethod.Get, redirectUri);
            req.Headers.Referrer = new Uri("https://secure.square-enix.com/");
            AddCookies(req, "login_group", "bridge_registration_token", "lang", "terms_token", "_bridge_session", "bridge_session_id_prd");

            res = await _client.SendAsync(req);

            // Extract authenticity_token
            loginContent = await res.Content.ReadAsStringAsync();
            var authTokenRegex = new Regex("name=\"authenticity_token\" value=\"(.*)\"");
            var authTokenMatch = authTokenRegex.Match(loginContent);

            var authTokenValue = !authTokenMatch.Success ? null : authTokenMatch.Groups[1].Value;
            return (authTokenValue, redirectUri);
        }

        private static async Task ConfirmTransfer(string authToken, string cautionUrl)
        {
            // Call to /i18n/ntv/288/update/commit
            var req = CreateRequest(HttpMethod.Post, "https://psg.sqex-bridge.jp/i18n/ntv/288/update/commit?lang=en");
            req.Headers.Add("Origin", "https://psg.sqex-bridge.jp");
            req.Headers.Referrer = new Uri(cautionUrl);
            AddCookies(req, "login_group", "_bridge_session", "bridge_registration_token", "lang", "terms_token", "bridge_session_id_prd");
            req.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("utf8","✓"),
                new KeyValuePair<string, string>("authenticity_token", authToken),
                new KeyValuePair<string, string>("button", ""),
                new KeyValuePair<string, string>("type", "2"),
                new KeyValuePair<string, string>("lang", "en"),
            });

            var res = await _client.SendAsync(req);
            UpdateCookies(res);

            // Redirect to /i18n/ntv/288/update/result
            var redirectUri = res.Headers.GetValues("Location").First();

            req = CreateRequest(HttpMethod.Get, redirectUri);
            req.Headers.Referrer = new Uri(cautionUrl);
            AddCookies(req, "login_group", "_bridge_session", "lang", "terms_token", "bridge_session_id_prd");

            res = await _client.SendAsync(req);
        }

        private static HttpRequestMessage CreateRequest(HttpMethod method, string url)
        {
            var req = new HttpRequestMessage(method, url);
            req.Headers.Add("x-requested-with", Application.Identifier);
            req.Headers.Add("upgrade-insecure-requests", "1");

            //req.Headers.Add("sec-fetch-user", "?1");
            //req.Headers.Add("sec-fetch-site", "none");
            //req.Headers.Add("sec-fetch-mode", "navigate");

            AddUserAgents(req);

            return req;
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

        private static void AddCookies(HttpRequestMessage req, params string[] cookieNames)
        {
            var cookies = new List<string>();
            foreach (var cookieName in cookieNames)
            {
                if (!_cookies.ContainsKey(cookieName) && string.IsNullOrEmpty(_cookies[cookieName]))
                    continue;

                cookies.Add($"{cookieName}={_cookies[cookieName]}");
            }

            req.Headers.Add("Cookie", cookies);
        }

        private static void UpdateCookies(HttpResponseMessage res)
        {
            foreach (var cookie in res.Headers.GetValues("Set-Cookie"))
            {
                var cookieSplit = cookie.Split(";")[0].Split("=");
                _cookies[cookieSplit[0]] = cookieSplit[1];
            }
        }
    }
}
