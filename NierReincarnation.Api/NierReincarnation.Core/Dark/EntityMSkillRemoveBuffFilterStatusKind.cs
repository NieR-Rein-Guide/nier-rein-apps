using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_remove_buff_filter_status_kind")]
public class EntityMSkillRemoveBuffFilterStatusKind
{
    [Key(0)]
    public int SkillRemoveBuffFilteringId { get; set; }

    [Key(1)]
    public int FilterIndex { get; set; }

    [Key(2)]
    public StatusKindType StatusKindType { get; set; }
}
