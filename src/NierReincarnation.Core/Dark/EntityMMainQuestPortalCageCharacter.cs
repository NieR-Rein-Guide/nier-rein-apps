using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMainQuestPortalCageCharacter))]
public class EntityMMainQuestPortalCageCharacter
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int PortalCageCharacterGroupId { get; set; }
}
