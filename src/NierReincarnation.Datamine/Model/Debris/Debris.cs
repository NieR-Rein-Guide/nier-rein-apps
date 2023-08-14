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

        stringBuilder.AppendLine($"**Debris:** {Name} - {Description} -> {(SourceType == DebrisSourceType.MISSION ? UnlockCondition : "Unknown source")}");
        stringBuilder.AppendLine();

        return stringBuilder.ToString();
    }
}
