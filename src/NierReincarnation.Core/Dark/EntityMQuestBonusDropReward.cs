using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestBonusDropReward))]
public class EntityMQuestBonusDropReward
{
    [Key(0)]
    public int QuestBonusEffectId { get; set; }

    [Key(1)]
    public PossessionType PossessionType { get; set; }

    [Key(2)]
    public int PossessionId { get; set; }

    [Key(3)]
    public int AdditionalCount { get; set; }
}
