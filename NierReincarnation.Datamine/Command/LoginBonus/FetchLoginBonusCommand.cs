using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchLoginBonusCommand : AbstractDbQueryCommand<FetchLoginBonusCommandArg, LoginBonus>
{
    public override async Task<LoginBonus> ExecuteAsync(FetchLoginBonusCommandArg arg)
    {
        if (!arg.IsValid()) return null;

        var darkLoginBonus = arg.Entity ?? MasterDb.EntityMLoginBonusTable.FindByLoginBonusId(arg.EntityId);
        if (darkLoginBonus == null) return null;

        if (arg.FromDate > CalculatorDateTime.FromUnixTime(darkLoginBonus.StartDatetime)) return null;
        if (arg.ToDate < CalculatorDateTime.FromUnixTime(darkLoginBonus.StartDatetime)) return null;

        return new LoginBonus
        {
            Name = $"loginbonus.title.{darkLoginBonus.LoginBonusAssetName}".Localize(),
            StartDateTimeOffset = CalculatorDateTime.FromUnixTime(darkLoginBonus.StartDatetime),
            EndDateTimeOffset = CalculatorDateTime.FromUnixTime(darkLoginBonus.EndDatetime),
            Rewards = arg.IncludeRewards
                ? await new FetchLoginBonusRewardsCommand().ExecuteAsync(new FetchLoginBonusRewardsCommandArg
                {
                    Entity = darkLoginBonus
                })
                : null
        };
    }
}

public class FetchLoginBonusCommandArg : AbstractEntityCommandWithDatesArg<EntityMLoginBonus>
{
    public bool IncludeRewards { get; init; }
}
