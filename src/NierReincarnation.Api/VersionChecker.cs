using System.Text.RegularExpressions;

namespace NierReincarnation;

public static partial class ApkMirrorVersionChecker
{
    private const string ApkMirrorUrl = "https://www.apkmirror.com/uploads/?appcategory=nier-reincarnation";

    [GeneratedRegex("<h5 title=\"NieR Re\\[in\\]carnation (\\d+\\.\\d+\\.\\d+)")]
    private static partial Regex HeadingRegex();

    public static async Task<string> GetCurrentVersion()
    {
        using HttpClient client = new();
        string content = await client.GetStringAsync(ApkMirrorUrl);

        var match = HeadingRegex().Matches(content).FirstOrDefault();

        return match != null ? match.Groups[1].Value : string.Empty;
    }
}
