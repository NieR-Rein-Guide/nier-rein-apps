using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllDebrisCommand : AbstractDbQueryCommand<FetchAllDebrisCommandArg, List<Debris>>
{
    public override async Task<List<Debris>> ExecuteAsync(FetchAllDebrisCommandArg arg)
    {
        List<Debris> debris = new();
        foreach (var darkDebris in MasterDb.EntityMThoughtTable.All)
        {
            var debri = await new FetchDebrisCommand().ExecuteAsync(new FetchDebrisByDebrisCommandArg
            {
                Entity = darkDebris,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            });

            if (debri != null)
            {
                debris.Add(debri);
            }
        }

        return debris;
    }
}

public class FetchAllDebrisCommandArg : AbstractCommandWithDatesArg
{
}
