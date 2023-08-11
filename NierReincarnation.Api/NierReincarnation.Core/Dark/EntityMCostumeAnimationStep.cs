using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_animation_step")]
public class EntityMCostumeAnimationStep
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public int Step { get; set; }

    [Key(2)]
    public int ActorAnimationId { get; set; }
}
