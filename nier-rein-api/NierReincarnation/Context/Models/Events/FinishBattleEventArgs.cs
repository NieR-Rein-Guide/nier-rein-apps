using System;
using Art.Framework.ApiNetwork.Grpc.Api.Quest;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Context.Models.Events
{
    public class FinishBattleEventArgs : EventArgs
    {
        public BattleDrops Rewards { get; }

        public FinishBattleEventArgs(BattleDrops rewards)
        {
            Rewards = rewards;
        }
    }

    public class Reward
    {
        public RewardCategory RewardCategory { get; }
        public PossessionType PossessionType { get; }
        public int PossessionId { get; }
        public string PossessionName { get; }
        public int Count { get; }

        public Reward(QuestReward reward) :
            this((RewardCategory)reward.RewardEffectId, (PossessionType)reward.PossessionType, reward.PossessionId,
                CalculatorPossession.GetItemName((PossessionType)reward.PossessionType, reward.PossessionId), reward.Count)
        { }

        public Reward(RewardCategory rewardCategory, PossessionType type, int id, string name, int count)
        {
            RewardCategory = rewardCategory;
            PossessionType = type;
            PossessionId = id;
            PossessionName = name;
            Count = count;
        }
    }
}
