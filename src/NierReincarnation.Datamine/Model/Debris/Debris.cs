using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class Debris
{
    public string Name { get; init; }

    public string Description { get; init; }

    public DebrisSourceType SourceType { get; set; }

    public string UnlockCondition { get; set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append("Debris: ".ToBold()).Append(Name).Append(" - ").Append(Description);

        if (SourceType != DebrisSourceType.COSTUME)
        {
            stringBuilder.Append(" -> ").AppendLine(SourceType == DebrisSourceType.MISSION ? UnlockCondition : "Unknown source");
        }

        return stringBuilder.ToString();
    }
}
