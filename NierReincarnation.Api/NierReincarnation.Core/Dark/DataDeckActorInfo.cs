using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark;

// CUSTOM: DataDeckActor with less information necessary to be loaded
public class DataDeckActorInfo
{
    public DataOutgameCostumeInfo Costume { get; set; }

    public int DressupCostumeId { get; set; }

    public DataWeaponInfo MainWeapon { get; set; }

    public DataWeaponInfo SubWeapon01 { get; set; }

    public DataWeaponInfo SubWeapon02 { get; set; }

    public DataOutgameCompanionInfo Companion { get; set; }

    public DataOutgameThoughtInfo Thought { get; set; }

    public DataOutgameMemoryInfo[] Memories { get; set; }

    public bool IsMinimal => DressupCostumeId == 0 && SubWeapon01 == null && SubWeapon02 == null &&
                             Companion == null && Thought == null && Memories.All(x => x == null);

    public DataDeckActorInfo()
    {
        Memories = new DataOutgameMemoryInfo[DeckServal.PARTS_MAX_COUNT];
    }
}
