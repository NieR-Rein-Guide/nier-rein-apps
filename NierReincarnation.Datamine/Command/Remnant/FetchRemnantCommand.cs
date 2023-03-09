using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchRemnantCommand : AbstractDbQueryCommand<FetchRemnantCommandArg, Remnant>
{
    public override Task<Remnant> ExecuteAsync(FetchRemnantCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<Remnant>(null);

        var darkRemnant = arg.Entity ?? MasterDb.EntityMStainedGlassTable.FindByStainedGlassId(arg.EntityId);
        if (darkRemnant == null) return Task.FromResult<Remnant>(null);

        if (arg.FromDate > CalculatorDateTime.FromUnixTime(darkRemnant.LockDisplayStartDatetime)) return Task.FromResult<Remnant>(null);
        if (arg.ToDate < CalculatorDateTime.FromUnixTime(darkRemnant.LockDisplayStartDatetime)) return Task.FromResult<Remnant>(null);

        var nameStr = $"stained.glass.title.{darkRemnant.TitleTextId}".Localize();
        var descStr = $"stained.glass.effect.{darkRemnant.EffectDescriptionTextId}".Localize().Replace("\\n", " ");

        if (string.IsNullOrWhiteSpace(nameStr)) return Task.FromResult<Remnant>(null);

        return Task.FromResult(new Remnant
        {
            Name = nameStr,
            Description = descStr,
            ReleaseDateTimeOffset = CalculatorDateTime.FromUnixTime(darkRemnant.LockDisplayStartDatetime)
        });
    }
}

public class FetchRemnantCommandArg : AbstractEntityCommandWithDatesArg<EntityMStainedGlass>
{
    public bool IncludeLocked { get; init; }
}
