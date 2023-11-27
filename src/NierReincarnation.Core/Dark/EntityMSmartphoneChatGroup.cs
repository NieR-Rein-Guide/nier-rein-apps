using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSmartphoneChatGroup))]
public class EntityMSmartphoneChatGroup
{
    [Key(0)]
    public int SmartphoneChatGroupId { get; set; }

    [Key(1)]
    public int SmartphoneGroupUnlockSceneId { get; set; }

    [Key(2)]
    public int SmartphoneGroupUnlockValue { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }

    [Key(4)]
    public int SmartphoneGroupEndSceneId { get; set; }
}
