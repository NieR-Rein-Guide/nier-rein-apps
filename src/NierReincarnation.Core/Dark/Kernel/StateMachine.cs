using NierReincarnation.Core.Dark.StateMachine;

namespace NierReincarnation.Core.Dark.Kernel;

public sealed class StateMachine
{
    public static void SetupFirstStateMachines()
    {
        ContextApi.ActiveContext.StateMachines.HandleNet = HandleNet.Generate();
    }
}
