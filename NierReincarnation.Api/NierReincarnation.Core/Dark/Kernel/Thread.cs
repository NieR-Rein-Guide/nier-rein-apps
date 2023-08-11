using System.Threading;

namespace NierReincarnation.Core.Dark.Kernel;

class Thread
{
    public static void SetupThread()
    {
        ContextApi.ActiveContext.Thread.Source = new CancellationTokenSource();
    }
}
