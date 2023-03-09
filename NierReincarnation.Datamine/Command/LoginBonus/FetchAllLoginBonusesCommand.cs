using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllLoginBonusesCommand : AbstractDbQueryCommand<FetchAllLoginBonusesCommandArg, List<LoginBonus>>
{
    public override async Task<List<LoginBonus>> ExecuteAsync(FetchAllLoginBonusesCommandArg arg)
    {
        List<LoginBonus> loginBonuses = new();
        foreach (var darkLoginBonus in MasterDb.EntityMLoginBonusTable.All)
        {
            var loginBonus = await new FetchLoginBonusCommand().ExecuteAsync(new FetchLoginBonusCommandArg
            {
                Entity = darkLoginBonus,
                IncludeRewards = arg.IncludeRewards,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            });

            if (loginBonus != null)
            {
                loginBonuses.Add(loginBonus);
            }
        }
        return loginBonuses;
    }
}

public class FetchAllLoginBonusesCommandArg : AbstractCommandWithDatesArg
{
    public bool IncludeRewards { get; init; }
}
