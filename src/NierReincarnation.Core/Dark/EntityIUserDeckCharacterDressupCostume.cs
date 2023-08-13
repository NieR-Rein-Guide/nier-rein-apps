using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_deck_character_dressup_costume")]
public class EntityIUserDeckCharacterDressupCostume
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserDeckCharacterUuid { get; set; }

    [Key(2)]
    public int DressupCostumeId { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
