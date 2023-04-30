using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserDeckSubWeaponGroupTable : TableBase<EntityIUserDeckSubWeaponGroup>
    {
        private readonly Func<EntityIUserDeckSubWeaponGroup, (long, string, string)> primaryIndexSelector;

        public EntityIUserDeckSubWeaponGroupTable(EntityIUserDeckSubWeaponGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.UserDeckCharacterUuid, element.UserWeaponUuid);
        }
    }
}
