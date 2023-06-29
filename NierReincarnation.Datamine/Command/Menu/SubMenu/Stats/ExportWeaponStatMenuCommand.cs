using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class ExportWeaponStatMenuCommand : AbstractMenuCommand<ExportWeaponStatMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportWeaponStatMenuCommand(ExportWeaponStatMenuCommandArg arg) : base(arg) { }

    public override async Task ExecuteAsync(ExportWeaponStatMenuCommandArg arg)
    {
        Weapon weapon = await new FetchWeaponCommand().ExecuteAsync(new FetchWeaponCommandArg
        {
            EntityId = arg.WeaponId
        });

        Console.WriteLine(weapon);
    }
}

public class ExportWeaponStatMenuCommandArg
{
    public int WeaponId { get; init; }
}
