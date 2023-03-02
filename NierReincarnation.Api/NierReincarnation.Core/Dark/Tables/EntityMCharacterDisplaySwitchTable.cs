using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCharacterDisplaySwitchTable : TableBase<EntityMCharacterDisplaySwitch> // TypeDefIndex: 11779
    {
        // Fields
        private readonly Func<EntityMCharacterDisplaySwitch, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B3EE70 Offset: 0x2B3EE70 VA: 0x2B3EE70
        public EntityMCharacterDisplaySwitchTable(EntityMCharacterDisplaySwitch[] sortedData):base(sortedData)
        {
            primaryIndexSelector = sw => sw.CharacterId;
        }

        // RVA: 0x2B3EF70 Offset: 0x2B3EF70 VA: 0x2B3EF70
        public EntityMCharacterDisplaySwitch FindByCharacterId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
