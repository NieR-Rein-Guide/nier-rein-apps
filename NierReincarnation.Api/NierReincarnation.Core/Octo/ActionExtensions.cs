using System;

namespace NierReincarnation.Core.Octo
{
    static class ActionExtensions
    {
        public static void TrySafeInvoke<T1>(this Action<T1> action, T1 param1)
        {
            try
            {
                action?.Invoke(param1);
            }
            catch { }
        }
    }
}
