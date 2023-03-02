using NierReincarnation.Core.Dark;

namespace NierReincarnation.Datamine.Command;

public abstract class AbstractDbQueryCommand : IAsyncCommand
{
    protected DarkMasterMemoryDatabase MasterDb => DatabaseDefine.Master;

    protected DarkUserMemoryDatabase UserDb => DatabaseDefine.User;

    public abstract Task ExecuteAsync();
}

public abstract class AbstractDbQueryCommand<TArgument> : IAsyncCommand<TArgument>
{
    protected DarkMasterMemoryDatabase MasterDb => DatabaseDefine.Master;

    protected DarkUserMemoryDatabase UserDb => DatabaseDefine.User;

    public abstract Task ExecuteAsync(TArgument arg);
}

public abstract class AbstractDbQueryCommand<TArgument, TResult> : IAsyncCommand<TArgument, TResult>
{
    protected DarkMasterMemoryDatabase MasterDb => DatabaseDefine.Master;

    protected DarkUserMemoryDatabase UserDb => DatabaseDefine.User;

    public abstract Task<TResult> ExecuteAsync(TArgument arg);
}
