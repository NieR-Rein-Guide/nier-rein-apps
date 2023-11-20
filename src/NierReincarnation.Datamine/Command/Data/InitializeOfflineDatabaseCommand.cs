using NierReincarnation.Core.Dark;
using NierReincarnation.Datamine.Extension;
using System.Runtime.CompilerServices;

namespace NierReincarnation.Datamine.Command;

public class InitializeOfflineDatabaseCommand : IAsyncCommand
{
    public async Task ExecuteAsync()
    {
        await InitializeMasterDbAsync();
        InitializeUserDb();
        NierReincarnationApp.IsSetup = true;
        NierReincarnationApp.IsInitialized = true;
    }

    private static async Task InitializeMasterDbAsync()
    {
        var latestLocalDbFileName = Directory.GetFiles(Path.Combine(Constants.DatabasePath, "bin")).OrderBy(x => x).LastOrDefault() ?? throw new Exception("Local DB file not found");
        string filePath = Path.Combine(Constants.DatabasePath, "bin", latestLocalDbFileName);

        var masterData = await File.ReadAllBytesAsync(latestLocalDbFileName);
        var decMasterData = MasterDataExtensions.DecryptMasterData(masterData);
        DatabaseDefine.Master = new DarkMasterMemoryDatabase(decMasterData)
        {
            Version = Path.GetFileNameWithoutExtension(latestLocalDbFileName).Split(".").FirstOrDefault()
        };
    }

    private static void InitializeUserDb()
    {
        DarkUserMemoryDatabase userDb = RuntimeHelpers.GetUninitializedObject(typeof(DarkUserMemoryDatabase)) as DarkUserMemoryDatabase;

        foreach (var prop in userDb.GetType().GetProperties())
        {
            var dataType = prop.PropertyType.BaseType.GetGenericArguments().FirstOrDefault();
            if (dataType == null) continue;
            var tableData = Array.CreateInstance(dataType, 0);
            var tableCtor = prop.PropertyType.GetConstructor(new[] { dataType.MakeArrayType() });
            var tableObj = tableCtor.Invoke(new object[] { tableData });
            prop.SetValue(userDb, tableObj);
        }

        DatabaseDefine.User = userDb;
    }
}
