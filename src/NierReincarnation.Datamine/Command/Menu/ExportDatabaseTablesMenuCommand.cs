using Newtonsoft.Json;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Datamine.Extension;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace NierReincarnation.Datamine.Command;

public class ExportDatabaseTablesMenuCommand : AbstractMenuCommand<ExportDatabaseTablesMenuCommandArg>
{
    private readonly ExportDatabaseTablesMenuCommandArg _Arg;

    public ExportDatabaseTablesMenuCommand(ExportDatabaseTablesMenuCommandArg arg) : base(arg)
    {
        _Arg = arg;
    }

    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool UseApi => !_Arg.ExportLocalDb;

    public override bool Reset => true;

    public override bool UseLocalizations => false;

    private static DataManager DataManager => OctoManager.DataManager;

    public override async Task ExecuteAsync(ExportDatabaseTablesMenuCommandArg arg)
    {
        if (_Arg.ExportLocalDb)
        {
            await ExportLocalMasterDb();
        }
        else
        {
            await ExportMasterDb();
            //await ExportUserDb();
        }
    }

    private static async Task ExportMasterDb()
    {
        string emptyString = string.Concat(Enumerable.Repeat(" ", 80));
        List<string> exportedTables = [];

        await Parallel.ForEachAsync(typeof(DarkMasterMemoryDatabase).GetProperties(), new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, async (tableProp, _) =>
        {
            var allProp = tableProp.PropertyType.GetProperty("All");
            if (allProp is null) return;

            Console.Write($"\r{emptyString}");
            Console.Write($"\rChecking {tableProp.Name}");
            var filePath = Path.Combine(Constants.DatabasePath, $"{tableProp.Name}.json");
            var tempFilePath = Path.Combine(Constants.DatabasePath, Constants.TempFolder, $"{DatabaseDefine.Master.Version}", $"{tableProp.Name}.json");
            var tableValue = tableProp.GetValue(DatabaseDefine.Master, null);
            var allValue = allProp.GetValue(tableValue, null);

            string json = JsonConvert.SerializeObject(allValue as IEnumerable, Formatting.Indented);

            // Skip file without changes
            if (File.Exists(filePath) && await File.ReadAllTextAsync(filePath, _) == json) return;

            // Write file with changes
            Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
            await File.WriteAllTextAsync(tempFilePath, json, _);
            exportedTables.Add(filePath);
        });
        Console.Write($"\r{emptyString}");
        Console.WriteLine();

        foreach (var exportedTable in exportedTables)
        {
            Console.WriteLine(exportedTable);
        }
    }

    private static async Task ExportUserDb()
    {
        string emptyString = string.Concat(Enumerable.Repeat(" ", 80));
        List<string> exportedTables = [];

        await Parallel.ForEachAsync(typeof(DarkUserMemoryDatabase).GetProperties(), new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, async (tableProp, _) =>
        {
            var allProp = tableProp.PropertyType.GetProperty("All");
            if (allProp is null) return;

            Console.Write($"\r{emptyString}");
            Console.Write($"\rChecking {tableProp.Name}");
            var filePath = Path.Combine(Constants.DatabasePath, $"{tableProp.Name}.json");
            var tempFilePath = Path.Combine(Constants.DatabasePath, Constants.TempFolder, $"{DatabaseDefine.Master.Version}", $"{tableProp.Name}.json");
            var tableValue = tableProp.GetValue(DatabaseDefine.User, null);
            var allValue = allProp.GetValue(tableValue, null);

            string json = JsonConvert.SerializeObject(allValue as IEnumerable, Formatting.Indented);

            // Skip file without changes
            if (File.Exists(filePath) && await File.ReadAllTextAsync(filePath, _) == json) return;

            // Write file with changes
            Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
            await File.WriteAllTextAsync(tempFilePath, json, _);
            exportedTables.Add(filePath);
        });
        Console.Write($"\r{emptyString}");
        Console.WriteLine();

        foreach (var exportedTable in exportedTables)
        {
            Console.WriteLine(exportedTable);
        }
    }

    private static async Task ExportLocalMasterDb()
    {
        var latestLocalDbFileName = Directory.GetFiles(Path.Combine(Constants.DatabasePath, "bin")).OrderBy(x => x).LastOrDefault();

        if (latestLocalDbFileName == null) return;

        var masterData = await File.ReadAllBytesAsync(latestLocalDbFileName);
        var decMasterData = MasterDataExtensions.DecryptMasterData(masterData);
        DarkMasterMemoryDatabase masterMemoryDatabase = new(decMasterData)
        {
            Version = Path.GetFileNameWithoutExtension(latestLocalDbFileName).Split(".").FirstOrDefault()
        };
        string emptyString = string.Concat(Enumerable.Repeat(" ", 80));
        List<string> exportedTables = [];

        await Parallel.ForEachAsync(typeof(DarkMasterMemoryDatabase).GetProperties(), new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, async (tableProp, _) =>
        {
            var allProp = tableProp.PropertyType.GetProperty("All");
            if (allProp is null) return;

            Console.Write($"\r{emptyString}");
            Console.Write($"\rChecking {tableProp.Name}");
            var filePath = Path.Combine(Constants.DatabasePath, $"{tableProp.Name}.json");
            var tempFilePath = Path.Combine(Constants.DatabasePath, Constants.TempFolder, $"{masterMemoryDatabase.Version}", $"{tableProp.Name}.json");
            var tableValue = tableProp.GetValue(masterMemoryDatabase, null);
            var allValue = allProp.GetValue(tableValue, null);

            string json = JsonConvert.SerializeObject(allValue as IEnumerable, Formatting.Indented);

            // Skip file without changes
            if (File.Exists(filePath) && await File.ReadAllTextAsync(filePath, _) == json) return;

            // Write file with changes
            Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
            await File.WriteAllTextAsync(tempFilePath, json, _);
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

public class ExportDatabaseTablesMenuCommandArg
{
    public bool ExportLocalDb { get; init; }
}
