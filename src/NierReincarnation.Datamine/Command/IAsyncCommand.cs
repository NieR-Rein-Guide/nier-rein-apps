namespace NierReincarnation.Datamine.Command;

public interface IAsyncCommand
{
    Task ExecuteAsync();
}

public interface IAsyncCommand<TArgument>
{
    Task ExecuteAsync(TArgument arg);
}

public interface IAsyncCommand<TArgument, TResult>
{
    Task<TResult> ExecuteAsync(TArgument arg);
}
