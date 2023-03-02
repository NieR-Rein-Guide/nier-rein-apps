using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserCharacterBoardAbilityTable : TableBase<EntityIUserCharacterBoardAbility> // TypeDefIndex: 12473
    {
        // Fields
        private readonly Func<EntityIUserCharacterBoardAbility, ValueTuple<long, int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC3FB0 Offset: 0x2DC3FB0 VA: 0x2DC3FB0
        public EntityIUserCharacterBoardAbilityTable(EntityIUserCharacterBoardAbility[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = ability => (ability.UserId, ability.CharacterId, ability.AbilityId);
        }

        public EntityIUserCharacterBoardAbility FindByUserIdAndCharacterIdAndAbilityId(ValueTuple<long, int, int> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2DC40B0 Offset: 0x2DC40B0 VA: 0x2DC40B0
        public bool TryFindByUserIdAndCharacterIdAndAbilityId(ValueTuple<long, int, int> key, out EntityIUserCharacterBoardAbility result)
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
