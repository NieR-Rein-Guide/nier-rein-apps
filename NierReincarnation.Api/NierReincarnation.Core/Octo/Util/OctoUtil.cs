namespace NierReincarnation.Core.Octo.Util;

internal static class OctoUtil
{
    public static string FastToLower(string s)
    {
        // Note: I don't have any interest in their "fast" conversion methods. Don't re-invent the wheel, kids. Especially if this code isn't even a
        // performance sink.
        return s.ToLower();
    }
}
