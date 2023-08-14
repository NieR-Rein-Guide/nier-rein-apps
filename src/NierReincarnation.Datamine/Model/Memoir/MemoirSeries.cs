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
        stringBuilder.AppendLine($"__**Memoir Series: {Name} ({Memoirs.FirstOrDefault().ReleaseDateTimeOffset.ToFormattedDate()})**__");
        stringBuilder.AppendLine($"**Small Set:** {SmallSet}");
        stringBuilder.AppendLine($"**Large Set:** {LargeSet}");
    }

    private void WriteMemoirSeriesPieces(StringBuilder stringBuilder)
    {
        foreach (var memoir in Memoirs.OrderBy(x => x.Order))
        {
            stringBuilder.AppendLine(memoir.ToString());
        }
    }
}
