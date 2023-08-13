using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_bonus")]
public class EntityMQuestBonus
{
    [Key(0)]
    public int QuestBonusId { get; set; }

    [Key(1)]
    public int QuestBonusCharacterGroupId { get; set; }

    [Key(2)]
    public int QuestBonusCostumeGroupId { get; set; }

    [Key(3)]
    public int QuestBonusWeaponGroupId { get; set; }

    [Key(4)]
    public int QuestBonusCostumeSettingGroupId { get; set; }

    [Key(5)]
    public int QuestBonusAllyCharacterId { get; set; }
}
