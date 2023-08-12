namespace NierReincarnation.Core.Octo.Caching;

internal enum CacheState
{
    None = 0,
    Old = 1,
    OldLocked = 2,
    Latest = 3
}
