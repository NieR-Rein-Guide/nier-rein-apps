namespace NierReincarnation.Core.Octo;

internal static class OctoExtensions
{
    public static bool IsNullOrEmpty<T>(this IList<T> list)
    {
        return list == null || list.Count == 0;
    }
}
