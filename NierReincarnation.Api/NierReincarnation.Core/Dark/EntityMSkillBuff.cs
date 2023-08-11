using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_buff")]
public class EntityMSkillBuff
{
    [Key(0)]
    public int SkillBuffId { get; set; }

    [Key(1)]
    public string BuffKey { get; set; }

    [Key(2)]
    public BuffType BuffType { get; set; }

    [Key(3)]
    public int Power { get; set; }

    [Key(4)]
    public int CooltimeFrameCount { get; set; }

    [Key(5)]
    public int IconId { get; set; }
}
