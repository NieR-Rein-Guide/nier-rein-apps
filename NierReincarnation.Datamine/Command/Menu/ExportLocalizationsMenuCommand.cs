using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Datamine.Extension;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace NierReincarnation.Datamine.Command;

public class ExportLocalizationsMenuCommand : AbstractMenuCommand<ExportLocalizationsMenuCommandArg>
{
    public override bool Reset => false;

    public override bool UseApi => false;

    public override bool UseLocalizations => false;

    public ExportLocalizationsMenuCommand(ExportLocalizationsMenuCommandArg arg) : base(arg)
    {
    }

    public override async Task ExecuteAsync(ExportLocalizationsMenuCommandArg arg)
    {
        foreach (var language in arg.Languages)
        {
            await ExportLocalizations(arg, language);
        }
    }

    private static async Task ExportLocalizations(ExportLocalizationsMenuCommandArg arg, Language language)
    {
        Dictionary<string, string> result = new();

        // Locate the directory
        string path = Path.Combine(Constants.LocalizationsPath, language.ToPath());
        if (!Directory.Exists(path)) return;

        // Delete existing file
        string filePath = Path.Combine(path, $"{Constants.AllLocalizationsFile}.txt");
        string filePathJson = Path.Combine(path, $"{Constants.AllLocalizationsFile}.json");
        DeleteFile(filePath);
        DeleteFile(filePathJson);

        // Read all files
        foreach (string file in Directory.EnumerateFiles(path, "*.txt", SearchOption.AllDirectories))
        {
            var fileName = Path.GetFileName(file);

            if (arg.Inclusions?.Count > 0 && !arg.Inclusions.Any(x => fileName.StartsWith(x))) continue;
            if (arg.Exclusions?.Count > 0 && arg.Exclusions.Any(x => fileName.StartsWith(x))) continue;

            foreach (string line in File.ReadAllLines(file))
            {
                if (string.IsNullOrEmpty(line) || line.StartsWith("//")) continue;

                string[] lineParts = line.Split(':');

                if (lineParts.Length < 2 || lineParts.All(x => string.IsNullOrEmpty(x))) continue;

                result.TryAdd(lineParts[0], string.Join(":", lineParts.Skip(1)));
            }
        }

        // Save new file
        await WriteTextFile(filePath, result);
        //await WriteJsonFile(filePathJson, result);
    }

    private static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath)) File.Delete(filePath);
    }

    private static Task WriteTextFile(string filePath, Dictionary<string, string> result)
    {
        return File.WriteAllLinesAsync(filePath, result.OrderBy(x => x.Key).Select(x => $"{x.Key}:{x.Value}"), Encoding.Unicode);
    }

    private static Task WriteJsonFile(string filePath, Dictionary<string, string> result)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        Dictionary<string, string> jsonResult = new();

        foreach (var kv in result.OrderBy(x => x.Key))
        {
            jsonResult.TryAdd(string.Concat(kv.Key.Split('.').Select(x => textInfo.ToTitleCase(x)).Select(x => char.IsNumber(x[0]) ? $"_{x}" : x).Select(x => x.Replace(" ", string.Empty))), kv.Value);
        }

        return File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(jsonResult, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping }), Encoding.Unicode);
    }
}

public class ExportLocalizationsMenuCommandArg
{
    public Language[] Languages { get; init; }

    public List<string> Inclusions { get; init; }

    public List<string> Exclusions { get; init; }
}
