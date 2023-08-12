namespace NierReincarnation.Core.Dark.Kernel;

internal class Thread
{
    public static void SetupThread()
    {
        ContextApi.ActiveContext.Thread.Source = new CancellationTokenSource();
    }
}
