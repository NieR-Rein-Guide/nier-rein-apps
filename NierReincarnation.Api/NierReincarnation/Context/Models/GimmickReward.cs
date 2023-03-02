using Art.Framework.ApiNetwork.Grpc.Api.CageOrnament;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Context.Models
{
    public class GimmickReward
    {
        public PossessionType PossessionType { get; }

        public int PossessionId { get; }

        public int Count { get; }

        public GimmickReward(Art.Framework.ApiNetwork.Grpc.Api.Gimmick.GimmickReward reward)
        {
            PossessionType = (PossessionType)reward.PossessionType;
            PossessionId = reward.PossessionId;
            Count = reward.Count;
        }

        public GimmickReward(CageOrnamentReward reward)
        {
            PossessionType = (PossessionType)reward.PossessionType;
            PossessionId = reward.PossessionId;
            Count = reward.Count;
        }
    }
}
