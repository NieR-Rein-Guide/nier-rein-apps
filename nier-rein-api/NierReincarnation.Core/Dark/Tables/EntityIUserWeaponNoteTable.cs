using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserWeaponNoteTable : TableBase<EntityIUserWeaponNote> // TypeDefIndex: 12609
    {
        // Fields
        private readonly Func<EntityIUserWeaponNote, ValueTuple<long, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C3D308 Offset: 0x2C3D308 VA: 0x2C3D308
        public EntityIUserWeaponNoteTable(EntityIUserWeaponNote[] sortedData):base(sortedData)
        {
            primaryIndexSelector = note => (note.UserId, note.WeaponId);
        }

        public EntityIUserWeaponNote FindByUserIdAndWeaponId(ValueTuple<long, int> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2C3D408 Offset: 0x2C3D408 VA: 0x2C3D408
        public bool TryFindByUserIdAndWeaponId(ValueTuple<long, int> key, out EntityIUserWeaponNote result)
        {
            result = null;

            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
