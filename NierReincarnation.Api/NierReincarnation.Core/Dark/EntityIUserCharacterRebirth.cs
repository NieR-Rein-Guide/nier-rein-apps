using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_character_rebirth")]
public class EntityIUserCharacterRebirth
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int RebirthCount { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
