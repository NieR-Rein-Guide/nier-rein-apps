using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark
{
    public class DataDeckActor
    {
       
        public string UserDeckActorUuid { get; set; }
       
        public DataOutgameCostume Costume { get; set; }
       
        public int DressupCostumeId { get; set; }
       
        public DataWeapon MainWeapon { get; set; }
       
        public DataWeapon SubWeapon01 { get; set; }
       
        public DataWeapon SubWeapon02 { get; set; }
       
        public DataOutgameCompanion Companion { get; set; }
       
        public DataOutgameMemory[] Memories { get; set; }
       
        public DataAbility[] MemorySeriesBonus { get; set; }
       
        public DataOutgameThought Thought { get; set; }
       
        public List<DataAbilityStatus> AbilityStatusList { get; set; }
       
        public List<DataAbilityStatus> DeckOtherDeckActorAbilityStatusList { get; set; }
       
        public int HpPower { get; set; }
       
        public int AttackPower { get; set; }
       
        public int VitalityPower { get; set; }
       
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
