namespace NierReincarnation.Core.Dark.Kernel
{
    // Dark.Kernel.ContextApi
    internal static class ContextApi
    {
       
        private static Context _activeContext;

        public static Context ActiveContext => _activeContext;

        public static Context CreateContext()
        {
            return new Context();
        }

        public static void DisposeContext(Context context, bool isCancelThread, bool isShutdownStateMachine)
        {
            _activeContext = null;

            // Shuts down everything game related, such as objects, scenes, and so on
        }

        public static void ActivateContext(Context context)
        {
            _activeContext = context;
        }
	}
}
