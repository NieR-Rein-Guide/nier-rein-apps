using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_gimmick")]
public class EntityMGimmick
{
    [Key(0)]
    public int GimmickId { get; set; }

    [Key(1)]
    public GimmickType GimmickType { get; set; }

    [Key(2)]
    public int GimmickOrnamentGroupId { get; set; }

    [Key(3)]
    public int ClearEvaluateConditionId { get; set; }

    [Key(4)]
    public int ReleaseEvaluateConditionId { get; set; }
}
