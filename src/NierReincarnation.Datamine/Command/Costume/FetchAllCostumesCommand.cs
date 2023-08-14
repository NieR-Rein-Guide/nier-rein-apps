using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllCostumesCommand : AbstractDbQueryCommand<FetchAllCostumesCommandArg, List<Costume>>
{
    public override async Task<List<Costume>> ExecuteAsync(FetchAllCostumesCommandArg arg)
    {
        List<Costume> costumes = new();
        foreach (var darkCostume in MasterDb.EntityMCostumeTable.All)
        {
            var costume = await new FetchCostumeCommand().ExecuteAsync(new FetchCostumeCommandArg
            {
                Entity = darkCostume,
                Awakenings = arg.Awakenings,
                IncludeStats = arg.IncludeStats,
                IncludeSkills = arg.IncludeSkills,
                IncludeAbilities = arg.IncludeAbilities,
                IncludeDebris = arg.IncludeDebris,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            });

            if (costume != null)
            {
                costumes.Add(costume);
            }
        }

        return costumes;
    }
}

public class FetchAllCostumesCommandArg : AbstractCommandWithDatesArg
{
    public int[] Awakenings { get; init; } = Array.Empty<int>();

    public bool IncludeStats { get; init; } = true;

    public bool IncludeSkills { get; init; } = true;

    public bool IncludeAbilities { get; init; } = true;

    public bool IncludeDebris { get; init; } = true;
}
