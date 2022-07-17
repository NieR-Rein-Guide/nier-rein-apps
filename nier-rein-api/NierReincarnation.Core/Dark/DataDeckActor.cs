using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark
{
    public class DataDeckActor
    {
        // 0x10
        public string UserDeckActorUuid { get; set; }
        // 0x18
        public DataOutgameCostume Costume { get; set; }
        // 0x20
        public int DressupCostumeId { get; set; }
        // 0x28
        public DataWeapon MainWeapon { get; set; }
        // 0x30
        public DataWeapon SubWeapon01 { get; set; }
        // 0x38
        public DataWeapon SubWeapon02 { get; set; }
        // 0x40
        public DataOutgameCompanion Companion { get; set; }
        // 0x48
        public DataOutgameMemory[] Memories { get; set; }
        // 0x50
        public DataAbility[] MemorySeriesBonus { get; set; }
        // 0x58
        public DataOutgameThought Thought { get; set; }
        // 0x60
        public List<DataAbilityStatus> AbilityStatusList { get; set; }
        // 0x68
        public List<DataAbilityStatus> DeckOtherDeckActorAbilityStatusList { get; set; }
        // 0x70
        public int HpPower { get; set; }
        // 0x74
        public int AttackPower { get; set; }
        // 0x78
        public int VitalityPower { get; set; }
        // 0x7C
        public int Power { get; set; }

        // CUSTOM: Holds the status values from the actor view in "Loadouts"
        public StatusValue StatusValue { get; set; }

        public bool IsEmpty => Costume == null || MainWeapon == null;

        public DataDeckActor()
        {
            Memories = new DataOutgameMemory[DeckServal.PARTS_MAX_COUNT];
            UserDeckActorUuid = Guid.NewGuid().ToString();
        }
    }
}
