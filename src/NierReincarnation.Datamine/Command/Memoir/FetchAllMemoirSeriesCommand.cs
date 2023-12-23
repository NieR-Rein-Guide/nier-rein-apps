using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllMemoirSeriesCommand : AbstractDbQueryCommand<FetchAllMemoirSeriesCommandArg, List<MemoirSeries>>
{
    public override async Task<List<MemoirSeries>> ExecuteAsync(FetchAllMemoirSeriesCommandArg arg)
    {
        List<MemoirSeries> memoirSerieses = [];
        foreach (var darkMemoirSeries in MasterDb.EntityMPartsSeriesTable.All)
        {
            var memoirSeries = await new FetchMemoirSeriesCommand().ExecuteAsync(new FetchMemoirSeriesCommandArg
            {
                Entity = darkMemoirSeries,
                IncludeMemoirs = arg.IncludeMemoirs,
                IncludeEmptySeries = arg.IncludeEmptySeries,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            });

            if (memoirSeries != null)
            {
                memoirSerieses.Add(memoirSeries);
            }
        }

        return memoirSerieses;
    }
}

public class FetchAllMemoirSeriesCommandArg : AbstractCommandWithDatesArg
{
    public bool IncludeMemoirs { get; init; } = true;

    public bool IncludeEmptySeries { get; init; }
}
