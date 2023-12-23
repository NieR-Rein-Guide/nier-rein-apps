using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchLoginBonusRewardsCommand : AbstractDbQueryCommand<FetchLoginBonusRewardsCommandArg, List<Reward>>
{
    public override Task<List<Reward>> ExecuteAsync(FetchLoginBonusRewardsCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<List<Reward>>(null);

        var darkLoginBonus = arg.Entity ?? MasterDb.EntityMLoginBonusTable.FindByLoginBonusId(arg.EntityId);
        if (darkLoginBonus == null) return Task.FromResult<List<Reward>>(null);

        List<Reward> rewards = [];

        foreach (var darkLoginBonusReward in MasterDb.EntityMLoginBonusStampTable.All.Where(x => x.LoginBonusId == darkLoginBonus.LoginBonusId))
        {
            rewards.Add(new Reward
            {
                Name = CalculatorPossession.GetItemName((PossessionType)darkLoginBonusReward.RewardPossessionType, darkLoginBonusReward.RewardPossessionId),
                Count = darkLoginBonusReward.RewardCount
            });
        }

        return Task.FromResult(rewards);
    }
}

public class FetchLoginBonusRewardsCommandArg : AbstractEntityCommandArg<EntityMLoginBonus>
{ }
