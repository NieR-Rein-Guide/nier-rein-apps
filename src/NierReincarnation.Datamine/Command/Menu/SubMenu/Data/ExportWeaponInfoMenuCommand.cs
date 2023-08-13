namespace NierReincarnation.Datamine.Command;

public class ExportWeaponInfoMenuCommand : AbstractMenuCommand
{
    public override async Task ExecuteAsync()
    {
        var weapons = await new FetchAllWeaponsCommand().ExecuteAsync(new FetchAllWeaponsCommandArg
        {
            IncludeStats = false,
            IncludeSkills = false,
            IncludeAbilities = false
        });

        foreach (var weapon in weapons.Select(x => new { x.AssetId, x.Name }).Distinct().OrderBy(x => x.AssetId))
        {
            Console.WriteLine($"{weapon.AssetId} - {weapon.Name}");
        }
    }
}
