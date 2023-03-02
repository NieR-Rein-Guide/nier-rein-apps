using System.Collections.Generic;

namespace NierReincarnation.Core.Octo
{
    static class OctoExtensions
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count <= 0;
        }
    }
}
