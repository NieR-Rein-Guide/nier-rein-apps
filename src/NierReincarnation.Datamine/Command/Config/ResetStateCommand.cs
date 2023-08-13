namespace NierReincarnation.Datamine.Command;

public class ResetStateCommand : IAsyncCommand
{
    public Task ExecuteAsync()
    {
        NierReincarnation.Reset();

        return Task.CompletedTask;
    }
}
