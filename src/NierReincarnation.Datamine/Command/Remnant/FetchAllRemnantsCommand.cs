using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllRemnantsCommand : AbstractDbQueryCommand<FetchAllRemnantsCommandArg, List<Remnant>>
{
    public override async Task<List<Remnant>> ExecuteAsync(FetchAllRemnantsCommandArg arg)
    {
        List<Remnant> remnants = new();

        foreach (var darkRemnant in MasterDb.EntityMStainedGlassTable.All)
        {
            if (arg.FromDate > CalculatorDateTime.FromUnixTime(darkRemnant.LockDisplayStartDatetime)) continue;
            if (arg.ToDate < CalculatorDateTime.FromUnixTime(darkRemnant.LockDisplayStartDatetime)) continue;

            var remnant = await new FetchRemnantCommand().ExecuteAsync(new FetchRemnantCommandArg
            {
                Entity = darkRemnant,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            });

            if (remnant != null)
            {
                remnants.Add(remnant);
            }
        }

        return remnants;
    }
}

public class FetchAllRemnantsCommandArg : AbstractCommandWithDatesArg
{
}
