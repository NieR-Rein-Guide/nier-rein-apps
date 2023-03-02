namespace NierReincarnation.Datamine.Command;

public class ExportCostumeInfoMenuCommand : AbstractMenuCommand
{
    public override async Task ExecuteAsync()
    {
        var costumes = await new FetchAllCostumesCommand().ExecuteAsync(new FetchAllCostumesCommandArg
        {
            IncludeStats = false,
            IncludeSkills = false,
            IncludeAbilities = false,
            IncludeDebris = false
        });

        foreach (var costume in costumes.OrderBy(x => x.AssetId))
        {
            Console.WriteLine($"{costume.AssetId} - {costume.Name}");
        }
    }
}
