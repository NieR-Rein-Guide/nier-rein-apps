using NierReincarnation.Context.Models.Events;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Context.Models;

public class QuestReward
{
    public RewardCategory RewardCategory { get; }

    public PossessionType PossessionType { get; }

    public int PossessionId { get; }

    public string PossessionName { get; }

    public int Count { get; }

    public QuestReward(Art.Framework.ApiNetwork.Grpc.Api.Quest.QuestReward reward) :
        this((RewardCategory)reward.RewardEffectId, (PossessionType)reward.PossessionType, reward.PossessionId,
            CalculatorPossession.GetItemName((PossessionType)reward.PossessionType, reward.PossessionId), reward.Count)
    { }

    public QuestReward(RewardCategory rewardCategory, PossessionType type, int id, string name, int count)
    {
        RewardCategory = rewardCategory;
        PossessionType = type;
        PossessionId = id;
        PossessionName = name;
        Count = count;
    }
}
