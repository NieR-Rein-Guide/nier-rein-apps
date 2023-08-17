using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Model;

public class Memoir
{
    public string Name { get; init; }

    public int Order { get; init; }

    public DateTimeOffset ReleaseDateTimeOffset { get; init; }

    public override string ToString()
    {
        return Name.ToListItem();
    }
}
