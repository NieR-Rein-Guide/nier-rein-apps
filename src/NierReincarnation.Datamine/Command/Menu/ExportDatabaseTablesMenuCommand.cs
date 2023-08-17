using Newtonsoft.Json;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using System.Collections;

namespace NierReincarnation.Datamine.Command;

public class ExportDatabaseTablesMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool Reset => true;

    public override bool UseLocalizations => false;

    internal static DataManager DataManager => OctoManager.Database as DataManager;

    public override async Task ExecuteAsync()
    {
        ExportMasterDb();
        //ExportUserDb();
    }

    private static void ExportMasterDb()
    {
        string emptyString = string.Concat(Enumerable.Repeat(" ", 80));
        List<string> exportedTables = new();

        typeof(DarkMasterMemoryDatabase).GetProperties().AsParallel().ForAll(async tableProp =>
        {
            Console.Write($"\r{emptyString}");
            Console.Write($"\rChecking {tableProp.Name}");
            var filePath = Path.Combine(Constants.DatabasePath, $"{tableProp.Name}.json");
            var tempFilePath = Path.Combine(Constants.DatabasePath, Constants.TempFolder, $"{DatabaseDefine.Master.Version}", $"{tableProp.Name}.json");
            var tableValue = tableProp.GetValue(DatabaseDefine.Master, null);
            var allProp = tableProp.PropertyType.GetProperty("All");
            if (allProp is null) return;
            var allValue = allProp.GetValue(tableValue, null);

            string json = JsonConvert.SerializeObject(allValue as IEnumerable, Formatting.Indented);

            // Skip file without changes
            if (File.Exists(filePath) && await File.ReadAllTextAsync(filePath) == json) return;

            // Write file with changes
            Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
            await File.WriteAllTextAsync(tempFilePath, json);
            exportedTables.Add(filePath);
        });
        Console.Write($"\r{emptyString}");
        Console.WriteLine();

        foreach (var exportedTable in exportedTables)
        {
            Console.WriteLine(exportedTable);
        }
    }

    private static void ExportUserDb()
    {
        string emptyString = string.Concat(Enumerable.Repeat(" ", 80));
        List<string> exportedTables = new();

        typeof(DarkUserMemoryDatabase).GetProperties().AsParallel().ForAll(async tableProp =>
        {
            Console.Write($"\r{emptyString}");
            Console.Write($"\rChecking {tableProp.Name}");
            var filePath = Path.Combine(Constants.DatabasePath, $"{tableProp.Name}.json");
            var tempFilePath = Path.Combine(Constants.DatabasePath, Constants.TempFolder, $"{DataManager.Revision}", $"{tableProp.Name}.json");
            var tableValue = tableProp.GetValue(DatabaseDefine.User, null);
            var allProp = tableProp.PropertyType.GetProperty("All");
            if (allProp is null) return;
            var allValue = allProp.GetValue(tableValue, null);

            string json = JsonConvert.SerializeObject(allValue as IEnumerable, Formatting.Indented);

            // Skip file without changes
            if (File.Exists(filePath) && await File.ReadAllTextAsync(filePath) == json) return;

            // Write file with changes
            Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
            await File.WriteAllTextAsync(tempFilePath, json);
            exportedTables.Add(filePath);
        });
        Console.Write($"\r{emptyString}");
        Console.WriteLine();

        foreach (var exportedTable in exportedTables)
        {
            Console.WriteLine(exportedTable);
        }
    }
}
