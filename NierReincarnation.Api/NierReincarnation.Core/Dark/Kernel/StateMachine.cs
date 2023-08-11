using NierReincarnation.Core.Dark.StateMachine;

namespace NierReincarnation.Core.Dark.Kernel;

// Dark.Kernel.StateMachine
public sealed class StateMachine
{
    public static void SetupFirstStateMachines()
    {
        ContextApi.ActiveContext.StateMachines.HandleNet = HandleNet.Generate();
    }
}
