using NierReincarnation.Core.AssetStudio;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Api.Localizations;

public abstract class BaseTextLocalizer : ITextLocalizer
{
    public abstract Task<Dictionary<string, string>> CreateAsync(SystemLanguage lang = SystemLanguage.English);

    protected Dictionary<string, string> ProcessAssets(List<TextAsset> textAssets)
    {
        Dictionary<string, string> result = [];

        foreach (var textAsset in textAssets)
        {
            foreach (var line in textAsset.Text.Replace(Environment.NewLine, "\n").Split('\n'))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//")) continue;

                try
                {
                    var colonIndex = line.IndexOf(':');
                    result[line[..colonIndex]] = line[(colonIndex + 1)..];
                }
                catch (Exception)
                {
                    // Ignored
                }
            }
        }

        return result;
    }
}
