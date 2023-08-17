using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class Remnant
{
    public string Name { get; init; }

    public string Description { get; init; }

    public DateTimeOffset ReleaseDateTimeOffset { get; init; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.AppendLine($"{Name} ({ReleaseDateTimeOffset.ToFormattedDate()})".ToBold());
        stringBuilder.AppendLine(Description);

        return stringBuilder.ToString();
    }
}
