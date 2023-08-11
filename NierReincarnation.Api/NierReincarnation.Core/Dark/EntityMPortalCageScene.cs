using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_portal_cage_scene")]
public class EntityMPortalCageScene
{
    [Key(0)]
    public int PortalCageSceneId { get; set; }

    [Key(1)]
    public int PortalCageCharacterGroupId { get; set; }

    [Key(2)]
    public int PortalCageDropId { get; set; }

    [Key(3)]
    public int PortalCageGateId { get; set; }
}
