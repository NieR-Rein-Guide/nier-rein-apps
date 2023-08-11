using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_mission_group")]
public class EntityMMissionGroup
{
    [Key(0)]
    public int MissionGroupId { get; set; }

    [Key(1)]
    public MissionCategoryType MissionCategoryType { get; set; }

    [Key(2)]
    public int LabelMissionTextId { get; set; }

    [Key(3)]
    public int SortOrderInLabel { get; set; }

    [Key(4)]
    public int AssetId { get; set; }

    [Key(5)]
    public int MissionGroupUnlockConditionGroupId { get; set; }

    [Key(6)]
    public int MissionSubCategoryId { get; set; }
}
