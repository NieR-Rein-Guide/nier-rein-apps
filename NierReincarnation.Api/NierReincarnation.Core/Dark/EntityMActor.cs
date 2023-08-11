using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_actor")]
public class EntityMActor
{
    [Key(0)]
    public int ActorId { get; set; }

    [Key(1)]
    public int NameActorTextId { get; set; }

    [Key(2)]
    public string ActorAssetId { get; set; }

    [Key(3)]
    public string ActorSpeakerIconAssetPath { get; set; }

    [Key(4)]
    public string AnimatorAssetPath { get; set; }
}
