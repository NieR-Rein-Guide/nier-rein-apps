namespace NierReincarnation.Datamine.Command;

public class UpdateAssetAutoCopyMenuCommand : UpdateConfigurationMenuCommand
{
    public UpdateAssetAutoCopyMenuCommand(UpdateConfigurationCommandArg arg) : base(arg) { }

    public override void UpdateConfiguration() => AppSettings.AutoCopyAssets = !AppSettings.AutoCopyAssets;
}
