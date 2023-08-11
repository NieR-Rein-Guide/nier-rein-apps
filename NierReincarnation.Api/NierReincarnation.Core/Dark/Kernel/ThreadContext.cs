using System.Collections.Generic;
using System.Threading;

namespace NierReincarnation.Core.Dark.Kernel
{
    // Dark.Kernel.ThreadContext
    class ThreadContext
    {
       
        public CancellationTokenSource Source { get; set; }
       
        public CancellationTokenSource WindowSystemScreenCancellationTokenSource { get; set; }
       
        public List<CancellationTokenSource> DialogCancellationTokenSource { get; }

        public ThreadContext()
        {
            DialogCancellationTokenSource = new List<CancellationTokenSource>();
        }
    }
}
