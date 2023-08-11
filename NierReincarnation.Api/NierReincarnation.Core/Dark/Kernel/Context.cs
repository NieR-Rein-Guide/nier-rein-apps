﻿namespace NierReincarnation.Core.Dark.Kernel;

// Dark.Kernel.Context
class Context
{
   
    public ApplicationContext Application { get; } = new ApplicationContext();
   
    public StateMachinesContext StateMachines { get; } = new StateMachinesContext();
   
    public ThreadContext Thread { get; } = new ThreadContext();
}
