using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_display_enemy_thumbnail_replace")]
public class EntityMQuestDisplayEnemyThumbnailReplace
{
    [Key(0)]
    public int QuestId { get; set; }

    [Key(1)]
    public int Priority { get; set; }

    [Key(2)]
    public EnemyThumbnailReplaceConditionType ReplaceConditionType { get; set; }

    [Key(3)]
    public EnemyThumbnailReplaceMethodType ReplaceMethodType { get; set; }

    [Key(4)]
    public int ReplaceValue { get; set; }
}
