using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllComanionsCommand : AbstractDbQueryCommand<FetchAllComanionsCommandArg, List<Companion>>
{
    public override async Task<List<Companion>> ExecuteAsync(FetchAllComanionsCommandArg arg)
    {
        List<Companion> companions = [];
        foreach (var darkCompanion in MasterDb.EntityMCompanionTable.All)
        {
            var companion = await new FetchComanionCommand().ExecuteAsync(new FetchComanionCommandArg
            {
                Entity = darkCompanion,
                IncludeStats = arg.IncludeStats,
                IncludeSkills = arg.IncludeSkills,
                IncludeAbilities = arg.IncludeAbilities,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            });

            if (companion != null)
            {
                companions.Add(companion);
            }
        }

        return companions;
    }
}

public class FetchAllComanionsCommandArg : AbstractCommandWithDatesArg
{
    public bool IncludeStats { get; init; } = true;

    public bool IncludeSkills { get; init; } = true;

    public bool IncludeAbilities { get; init; } = true;
}
