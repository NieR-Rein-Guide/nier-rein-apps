namespace NierReincarnation.Context.Models;

public class BattleResult
{
    public BattleStatus Status { get; }

    public BattleDrops Rewards { get; }

    public BattleResult(BattleStatus status, BattleDrops rewards = null)
    {
        Status = status;
        Rewards = rewards;
    }
}
