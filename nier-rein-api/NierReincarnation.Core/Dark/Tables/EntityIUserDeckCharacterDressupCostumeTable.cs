using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserDeckCharacterDressupCostumeTable : TableBase<EntityIUserDeckCharacterDressupCostume> // TypeDefIndex: 12755
    {
        // Fields
        private readonly Func<EntityIUserDeckCharacterDressupCostume, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x373B304 Offset: 0x373B304 VA: 0x373B304
        public EntityIUserDeckCharacterDressupCostumeTable(EntityIUserDeckCharacterDressupCostume[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = costume => (costume.UserId, costume.UserDeckCharacterUuid);
        }

        public EntityIUserDeckCharacterDressupCostume FindByUserIdAndUserDeckCharacterUuid(ValueTuple<long, string> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x373B404 Offset: 0x373B404 VA: 0x373B404
        public bool TryFindByUserIdAndUserDeckCharacterUuid(ValueTuple<long, string> key, out EntityIUserDeckCharacterDressupCostume result)
        {
            result = null;

            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
