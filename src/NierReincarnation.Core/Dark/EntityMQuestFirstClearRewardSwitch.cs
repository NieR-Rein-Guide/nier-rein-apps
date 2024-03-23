using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestFirstClearRewardSwitch))]
public class EntityMQuestFirstClearRewardSwitch
{
    [Key(0)]
    public int QuestId { get; set; }

    [Key(1)]
    public int QuestFirstClearRewardGroupId { get; set; }

    [Key(2)]
    public int SwitchConditionClearQuestId { get; set; }
}
