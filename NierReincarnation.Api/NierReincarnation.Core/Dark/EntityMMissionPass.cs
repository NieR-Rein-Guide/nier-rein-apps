using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_mission_pass")]
public class EntityMMissionPass
{
    [Key(0)]
    public int MissionPassId { get; set; }

    [Key(1)]
    public long StartDatetime { get; set; }

    [Key(2)]
    public long EndDatetime { get; set; }

    [Key(3)]
    public int PremiumItemId { get; set; }

    [Key(4)]
    public int MissionPassLevelGroupId { get; set; }

    [Key(5)]
    public int MissionPassRewardGroupId { get; set; }
}
