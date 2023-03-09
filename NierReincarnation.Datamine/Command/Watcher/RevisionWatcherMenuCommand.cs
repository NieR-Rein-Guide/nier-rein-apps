using static NierReincarnation.Core.Octo.OctoManager;

namespace NierReincarnation.Datamine.Command;

public class RevisionWatcherMenuCommand : AbstractWatcherMenuCommand<RevisionWatcherMenuCommandArg, WatcherResult>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool Reset => true;

    public override bool Login => false;

    public override int Revision => Program.AppSettings.DbRevision;

    public override int Interval => 5000;

    private static int DbRevision => Internal._dataManager.Revision;

    public RevisionWatcherMenuCommand(RevisionWatcherMenuCommandArg arg) : base(arg)
    {
    }

    public override Task<WatcherResult> ExecuteAsync(RevisionWatcherMenuCommandArg arg)
    {
        if (DbRevision > Revision)
        {
            WriteLineWithTimestamp($"New revision detected -> {DbRevision}");
            return Task.FromResult(new WatcherResult(true));
        }
        else
        {
            WriteLineWithTimestamp("No new revision");
            return Task.FromResult(new WatcherResult(false));
        }
    }
}

public class RevisionWatcherMenuCommandArg
{
}
