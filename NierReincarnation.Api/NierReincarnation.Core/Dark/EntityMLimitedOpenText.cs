using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_limited_open_text")]
public class EntityMLimitedOpenText
{
    [Key(0)]
    public LimitedOpenTargetType LimitedOpenTargetType { get; set; }

    [Key(1)]
    public int TargetId { get; set; }

    [Key(2)]
    public int OpenAchievementTextAssetId { get; set; }

    [Key(3)]
    public int LocalPushTextAssetId { get; set; }

    [Key(4)]
    public int OpenAchievementTextGroupId { get; set; }
}
