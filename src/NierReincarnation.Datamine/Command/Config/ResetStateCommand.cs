using NierReincarnation.Api;

namespace NierReincarnation.Datamine.Command;

public class ResetStateCommand : IAsyncCommand
{
    public Task ExecuteAsync()
    {
        NierReincarnationApp.ResetApplication();

        return Task.CompletedTask;
    }
}
