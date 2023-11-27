using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserStatus))]
public class EntityIUserStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int Level { get; set; }

    [Key(2)]
    public int Exp { get; set; }

    [Key(3)]
    public int StaminaMilliValue { get; set; }

    [Key(4)]
    public long StaminaUpdateDatetime { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
