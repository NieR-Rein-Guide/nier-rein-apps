using NierReincarnation.Context.Models.Events;

namespace NierReincarnation.Context.Models
{
    public class BattleDrops
    {
        public Reward[] DropRewards { get; }
        public Reward[] FirstClearRewards { get; }
        public Reward[] MissionRewards { get; }
        public Reward[] MissionCompleteRewards { get; }

        public BattleDrops(Reward[] drops, Reward[] firstClears, Reward[] missions, Reward[] missionsComplete)
        {
            DropRewards = drops;
            FirstClearRewards = firstClears;
            MissionRewards = missions;
            MissionCompleteRewards = missionsComplete;
        }
    }
}
