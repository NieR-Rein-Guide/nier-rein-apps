using System.Linq;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark
{
    // CUSTOM: DataDeckActor with less information necessary to be loaded
    public class DataDeckActorInfo
    {
        // 0x10
        public DataOutgameCostumeInfo Costume { get; set; }
        // 0x18
        public int DressupCostumeId { get; set; }
        // 0x20
        public DataWeaponInfo MainWeapon { get; set; }
        // 0x28
        public DataWeaponInfo SubWeapon01 { get; set; }
        // 0x30
        public DataWeaponInfo SubWeapon02 { get; set; }
        // 0x38
        public DataOutgameCompanionInfo Companion { get; set; }
        // 0x40
        public DataOutgameThoughtInfo Thought { get; set; }
        // 0x48
        public DataOutgameMemoryInfo[] Memories { get; set; }

        public bool IsMinimal => DressupCostumeId == 0 && SubWeapon01 == null && SubWeapon02 == null &&
                                 Companion == null && Thought == null && Memories.All(x => x == null);

        public DataDeckActorInfo()
        {
            Memories = new DataOutgameMemoryInfo[DeckServal.PARTS_MAX_COUNT];
        }
    }
}
