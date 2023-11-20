using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public static class OfflineTextLocalizer
{
    public static IDictionary<string, string> Create(SystemLanguage lang = SystemLanguage.English)
    {
        Dictionary<string, string> result = new();

        string filePath = Path.Combine(Constants.LocalizationsPath, lang.ToPath(), $"{Constants.AllLocalizationsFile}.txt");

        foreach (var line in File.ReadAllLines(filePath))
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

        return result;
    }
}
