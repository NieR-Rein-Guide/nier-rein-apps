using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleEnemySizeTypeConfigTable : TableBase<EntityMBattleEnemySizeTypeConfig>
    {
        private readonly Func<EntityMBattleEnemySizeTypeConfig, (int,int)> primaryIndexSelector;

        public EntityMBattleEnemySizeTypeConfigTable(EntityMBattleEnemySizeTypeConfig[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeAssetCategoryType,element.ActorSkeletonId);
        }
        
        public bool TryFindByCostumeAssetCategoryTypeAndActorSkeletonId(ValueTuple<int, int> key, out EntityMBattleEnemySizeTypeConfig result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key, out result); }

    }
}
