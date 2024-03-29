using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestLabyrinthQuestDisplay))]
public class EntityMEventQuestLabyrinthQuestDisplay
{
    [Key(0)]
    public int QuestId { get; set; }

    [Key(1)]
    public int BgAssetId { get; set; }

    [Key(2)]
    public int MobId { get; set; }
}
