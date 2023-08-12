namespace NierReincarnation.Core.Octo.Data;

[Flags]
public enum ItemType : byte
{
    Minimum = 0,
    WithDeps = 1,
    WithTags = 2,
    WithDepsAndTags = WithDeps | WithTags
}
