using Newtonsoft.Json;

namespace NierReincarnation.Datamine.Command;

public class SaveConfigurationCommand : IAsyncCommand
{
    public async Task ExecuteAsync()
    {
        await File.WriteAllTextAsync(Constants.SettingsPath, JsonConvert.SerializeObject(Program.AppSettings, Formatting.Indented));
    }
}
