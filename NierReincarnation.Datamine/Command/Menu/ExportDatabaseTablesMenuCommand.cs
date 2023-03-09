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

    internal static DataManager DataManager => OctoManager.Database as DataManager;

    public override async Task ExecuteAsync()
    {
        string emptyString = string.Concat(Enumerable.Repeat(" ", 80));
        List<string> exportedTables = new();

        foreach (var tableProp in typeof(DarkMasterMemoryDatabase).GetProperties())
        {
            Console.Write($"\r{emptyString}");
            Console.Write($"\rChecking {tableProp.Name}");
            var filePath = Path.Combine(Constants.DatabasePath, $"{tableProp.Name}.json");
            var tempFilePath = Path.Combine(Constants.DatabasePath, Constants.TempFolder, $"{DataManager.Revision}", $"{tableProp.Name}.json");
            var tableValue = tableProp.GetValue(DatabaseDefine.Master, null);
            var allProp = tableProp.PropertyType.GetProperty("All");
            var allValue = allProp.GetValue(tableValue, null);

            string json = JsonConvert.SerializeObject(allValue as IEnumerable, Formatting.Indented);

            // Skip file without changes
            if (File.Exists(filePath) && await File.ReadAllTextAsync(filePath) == json) continue;

            // Write file with changes
            if (Program.AppSettings.UseTemp)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
            }
            await File.WriteAllTextAsync(Program.AppSettings.UseTemp ? tempFilePath : filePath, json);
            exportedTables.Add(filePath);
        }
        Console.Write($"\r{emptyString}");
        Console.WriteLine();

        foreach (var exportedTable in exportedTables)
        {
            Console.WriteLine(exportedTable);
        }
    }
}
