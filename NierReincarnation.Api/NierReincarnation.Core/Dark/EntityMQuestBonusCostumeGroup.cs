using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_bonus_costume_group")]
public class EntityMQuestBonusCostumeGroup
{
    [Key(0)]
    public int QuestBonusCostumeGroupId { get; set; }

    [Key(1)]
    public int CostumeId { get; set; }

    [Key(2)]
    public int QuestBonusEffectGroupId { get; set; }

    [Key(3)]
    public int QuestBonusTermGroupId { get; set; }
}
