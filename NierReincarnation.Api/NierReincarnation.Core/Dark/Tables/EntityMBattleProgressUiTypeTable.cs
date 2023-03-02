using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleProgressUiTypeTable : TableBase<EntityMBattleProgressUiType>
    {
        private readonly Func<EntityMBattleProgressUiType, int> primaryIndexSelector;

        public EntityMBattleProgressUiTypeTable(EntityMBattleProgressUiType[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestSceneId;
        }
        
        public bool TryFindByQuestSceneId(int key, out EntityMBattleProgressUiType result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
