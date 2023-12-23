using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchMemoirsCommand : AbstractDbQueryCommand<FetchMemoirsCommandArg, List<Memoir>>
{
    public override Task<List<Memoir>> ExecuteAsync(FetchMemoirsCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<List<Memoir>>(null);

        var darkMemoirSeries = arg.Entity ?? MasterDb.EntityMPartsSeriesTable.FindByPartsSeriesId(arg.EntityId);
        if (darkMemoirSeries == null) return Task.FromResult<List<Memoir>>(null);

        List<Memoir> memoirs = [];
        List<int> memoirGroupIds = [];

        foreach (var darkMemoir in MasterDb.EntityMPartsTable.All.OrderByDescending(x => x.RarityType).ThenBy(x => x.PartsId))
        {
            if (darkMemoir.PartsId >= 8000 || memoirGroupIds.Contains(darkMemoir.PartsGroupId)) continue;

            memoirGroupIds.Add(darkMemoir.PartsGroupId);
            var darkMemoirGroup = MasterDb.EntityMPartsGroupTable.FindByPartsGroupId(darkMemoir.PartsGroupId);

            if (darkMemoirGroup.PartsSeriesId != darkMemoirSeries.PartsSeriesId) continue;

            var darkMemoirCatalog = MasterDb.EntityMCatalogPartsGroupTable.FindByPartsGroupId(darkMemoirGroup.PartsGroupId);
            var termCatalog = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(darkMemoirCatalog?.CatalogTermId ?? 0);

            if (termCatalog != null)
            {
                if (arg.FromDate > CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) continue;
                if (arg.ToDate < CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) continue;
            }

            memoirs.Add(new Memoir
            {
                Name = CalculatorMemory.MemoryName(darkMemoir.PartsId),
                ReleaseDateTimeOffset = termCatalog != null ? CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime) : DateTimeOffset.MaxValue,
                Order = memoirs.Count + 1
            });
        }

        return Task.FromResult(memoirs);
    }
}

public class FetchMemoirsCommandArg : AbstractEntityCommandWithDatesArg<EntityMPartsSeries>
{ }
