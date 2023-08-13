using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_character_voice_unlock_condition")]
public class EntityMCharacterVoiceUnlockCondition
{
    [Key(0)]
    public int CharacterId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public CharacterVoiceUnlockConditionType CharacterVoiceUnlockConditionType { get; set; }

    [Key(3)]
    public int ConditionValue { get; set; }

    [Key(4)]
    public int VoiceAssetId { get; set; }
}
