namespace NierReincarnation.Core.Dark.Kernel;

public sealed class Thread
{
    public static void SetupThread()
    {
        ContextApi.ActiveContext.Thread.Source = new CancellationTokenSource();
    }
}
