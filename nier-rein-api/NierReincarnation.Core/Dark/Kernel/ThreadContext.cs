using System.Collections.Generic;
using System.Threading;

namespace NierReincarnation.Core.Dark.Kernel
{
    // Dark.Kernel.ThreadContext
    class ThreadContext
    {
        // 0x10
        public CancellationTokenSource Source { get; set; }
        // 0x18
        public CancellationTokenSource WindowSystemScreenCancellationTokenSource { get; set; }
        // 0x20
        public List<CancellationTokenSource> DialogCancellationTokenSource { get; }

        public ThreadContext()
        {
            DialogCancellationTokenSource = new List<CancellationTokenSource>();
        }
    }
}
