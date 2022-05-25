namespace NierReincarnation.Core.Dark.Kernel
{
    // Dark.Kernel.Context
    class Context
    {
        // 0x10
        public ApplicationContext Application { get; } = new ApplicationContext();
        // 0x68
        public StateMachinesContext StateMachines { get; } = new StateMachinesContext();
        // 0x78
        public ThreadContext Thread { get; } = new ThreadContext();
    }
}
