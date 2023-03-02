using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleGeneralViewConfigurationTable : TableBase<EntityMBattleGeneralViewConfiguration>
    {
        private readonly Func<EntityMBattleGeneralViewConfiguration, (int,int)> primaryIndexSelector;

        public EntityMBattleGeneralViewConfigurationTable(EntityMBattleGeneralViewConfiguration[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestSceneId,element.WaveNumber);
        }
        
        public bool TryFindByQuestSceneIdAndWaveNumber(ValueTuple<int, int> key, out EntityMBattleGeneralViewConfiguration result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key, out result); }

    }
}
