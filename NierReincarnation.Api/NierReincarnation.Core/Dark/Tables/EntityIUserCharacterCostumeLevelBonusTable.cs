using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserCharacterCostumeLevelBonusTable : TableBase<EntityIUserCharacterCostumeLevelBonus> // TypeDefIndex: 12481
    {
        // Fields
        private readonly Func<EntityIUserCharacterCostumeLevelBonus, (long, int, StatusCalculationType)> primaryIndexSelector; // 0x18
        private readonly Func<EntityIUserCharacterCostumeLevelBonus, int> secondaryIndex0Selector; // 0x28

        // Methods

        // RVA: 0x2DC5EE8 Offset: 0x2DC5EE8 VA: 0x2DC5EE8
        public EntityIUserCharacterCostumeLevelBonusTable(EntityIUserCharacterCostumeLevelBonus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.CharacterId, user.StatusCalculationType);
            secondaryIndex0Selector = user => user.CharacterId;
        }

        public EntityIUserCharacterCostumeLevelBonus FindByUserIdAndCharacterIdAndStatusCalculationType((long, int, StatusCalculationType) key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2DC60A0 Offset: 0x2DC60A0 VA: 0x2DC60A0
        public bool TryFindByUserIdAndCharacterIdAndStatusCalculationType((long, int, StatusCalculationType) key, out EntityIUserCharacterCostumeLevelBonus result)
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

        // RVA: 0x2DC6134 Offset: 0x2DC6134 VA: 0x2DC6134
        public RangeView<EntityIUserCharacterCostumeLevelBonus> FindByCharacterId(int key)
        {
            var result = new List<EntityIUserCharacterCostumeLevelBonus>();

            foreach (var element in data)
                if (secondaryIndex0Selector(element) == key)
                    result.Add(element);

            return new RangeView<EntityIUserCharacterCostumeLevelBonus>(result.ToArray(), 0, result.Count - 1, true);
            ;
        }
    }
}
