using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchMemoirSeriesCommand : AbstractDbQueryCommand<FetchMemoirSeriesCommandArg, MemoirSeries>
{
    public override async Task<MemoirSeries> ExecuteAsync(FetchMemoirSeriesCommandArg arg)
    {
        if (!arg.IsValid()) return null;

        var darkMemoirSeries = arg.Entity ?? MasterDb.EntityMPartsSeriesTable.FindByPartsSeriesId(arg.EntityId);
        if (darkMemoirSeries == null) return null;

        List<Memoir> memoirs = arg.IncludeMemoirs
            ? await new FetchMemoirsCommand().ExecuteAsync(new FetchMemoirsCommandArg
            {
                Entity = darkMemoirSeries,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            })
            : [];

        if (!arg.IncludeEmptySeries && memoirs.Count == 0) return null;

        var abilityGroup = CalculatorMemory.GetEntityMPartsSeriesBonusAbilityGroup(darkMemoirSeries.PartsSeriesBonusAbilityGroupId, CalculatorMemory.kMaxBonusSetCount);
        var smallAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup[0].AbilityId, abilityGroup[0].AbilityLevel);
        var largeAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup[1].AbilityId, abilityGroup[1].AbilityLevel);

        return new MemoirSeries
        {
            Name = CalculatorMemory.MemorySeriesName(darkMemoirSeries.PartsSeriesId),
            SmallSet = CalculatorAbility.GetDescriptionLong(smallAbilityDetail.DescriptionAbilityTextId),
            LargeSet = CalculatorAbility.GetDescriptionLong(largeAbilityDetail.DescriptionAbilityTextId),
            Memoirs = memoirs
        };
    }
}

public class FetchMemoirSeriesCommandArg : AbstractEntityCommandWithDatesArg<EntityMPartsSeries>
{
    public bool IncludeMemoirs { get; init; } = true;

    public bool IncludeEmptySeries { get; init; }
}
