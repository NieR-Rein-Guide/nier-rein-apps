using System;

namespace NierReincarnation.Context.Models.Events;

public class StartBattleEventArgs : EventArgs
{
    public RewardCategory[] RewardCategories { get; }

    public bool ShouldQuitBattle { get; set; }

    public bool ForceShutdown { get; set; }

    public StartBattleEventArgs(RewardCategory[] rewards)
    {
        RewardCategories = rewards;
    }
}

public enum RewardCategory
{
    NORMAL,
    RARE,
    S_RARE,
    SS_RARE,
}
