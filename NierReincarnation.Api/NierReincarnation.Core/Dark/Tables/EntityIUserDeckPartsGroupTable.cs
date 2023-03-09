using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserDeckPartsGroupTable : TableBase<EntityIUserDeckPartsGroup> // TypeDefIndex: 12501
    {
        // Fields
        private readonly Func<EntityIUserDeckPartsGroup, ValueTuple<long, string, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35A58B8 Offset: 0x35A58B8 VA: 0x35A58B8
        public EntityIUserDeckPartsGroupTable(EntityIUserDeckPartsGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.UserDeckCharacterUuid, user.UserPartsUuid);
        }

        public EntityIUserDeckPartsGroup FindByUserIdAndUserDeckCharacterUuidAndUserPartsUuid((long,string,string) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
