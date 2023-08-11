using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_gimmick_extra_quest")]
public class EntityMGimmickExtraQuest
{
    [Key(0)]
    public int GimmickId { get; set; }

    [Key(1)]
    public int GimmickOrnamentIndex { get; set; }

    [Key(2)]
    public int ExtraQuestId { get; set; }
}
