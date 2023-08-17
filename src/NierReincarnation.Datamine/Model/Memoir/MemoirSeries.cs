using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class MemoirSeries
{
    public string Name { get; init; }

    public string SmallSet { get; init; }

    public string LargeSet { get; init; }

    public List<Memoir> Memoirs { get; init; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        // Memoir Series
        WriteMemoirSeriesInfo(stringBuilder);

        // Memoirs Pieces
        WriteMemoirSeriesPieces(stringBuilder);

        stringBuilder.AppendLine();

        return stringBuilder.ToString();
    }

    private void WriteMemoirSeriesInfo(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine($"Memoir Series: {Name} ({Memoirs.FirstOrDefault().ReleaseDateTimeOffset.ToFormattedDate()})".ToHeader2());
        stringBuilder.Append("Small Set: ".ToBold()).AppendLine(SmallSet);
        stringBuilder.Append("Large Set: ".ToBold()).AppendLine(LargeSet);
    }

    private void WriteMemoirSeriesPieces(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine("Pieces: ".ToBold());
        foreach (var memoir in Memoirs.OrderBy(x => x.Order))
        {
            stringBuilder.AppendLine(memoir.ToString());
        }
    }
}
