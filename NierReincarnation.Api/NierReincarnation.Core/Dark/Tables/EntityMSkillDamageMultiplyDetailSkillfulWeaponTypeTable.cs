using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillDamageMultiplyDetailSkillfulWeaponTypeTable : TableBase<EntityMSkillDamageMultiplyDetailSkillfulWeaponType>
{
    private readonly Func<EntityMSkillDamageMultiplyDetailSkillfulWeaponType, int> primaryIndexSelector;

    public EntityMSkillDamageMultiplyDetailSkillfulWeaponTypeTable(EntityMSkillDamageMultiplyDetailSkillfulWeaponType[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillDamageMultiplyDetailId;
    }

    public bool TryFindBySkillDamageMultiplyDetailId(int key, out EntityMSkillDamageMultiplyDetailSkillfulWeaponType result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
