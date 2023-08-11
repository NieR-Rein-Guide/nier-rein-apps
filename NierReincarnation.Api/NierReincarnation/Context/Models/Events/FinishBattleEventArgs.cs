using System;

namespace NierReincarnation.Context.Models.Events;

public class FinishBattleEventArgs : EventArgs
{
    public BattleDrops Rewards { get; }

    public FinishBattleEventArgs(BattleDrops rewards)
    {
        Rewards = rewards;
    }
}
