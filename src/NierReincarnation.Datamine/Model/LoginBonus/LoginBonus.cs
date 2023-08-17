using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class LoginBonus
{
    public string Name { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<Reward> Rewards { get; init; }

    public bool CanGroupRewards => Rewards?.All(x => x.Name == Rewards[0].Name) == true;

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        // Login Bonus
        WriteLoginBonusInfo(stringBuilder);

        // Login Bonus Rewards
        WriteLoginBonusRewards(stringBuilder);

        return stringBuilder.ToString();
    }

    private void WriteLoginBonusInfo(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine($"{Name} {this.ToFormattedDateStr()}".ToBold());
    }

    private void WriteLoginBonusRewards(StringBuilder stringBuilder)
    {
        if (Rewards == null) return;

        if (CanGroupRewards)
        {
            stringBuilder.AppendLine($"{Rewards[0].Name} x{Rewards.Sum(x => x.Count)}");
        }
        else
        {
            foreach (var loginBonusReward in Rewards)
            {
                stringBuilder.AppendLine($"{loginBonusReward.Name} x{loginBonusReward.Count}".ToListItem());
            }
        }
    }
}
