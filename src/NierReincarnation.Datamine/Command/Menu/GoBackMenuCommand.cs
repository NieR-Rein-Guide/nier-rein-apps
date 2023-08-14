namespace NierReincarnation.Datamine.Command;

public class GoBackMenuCommand : AbstractSimpleMenuCommand
{
    public override bool Reset => false;

    public override bool UseApi => false;

    public override bool UseLocalizations => false;

    public override void Execute()
    {
        // Do nothing
    }
}
