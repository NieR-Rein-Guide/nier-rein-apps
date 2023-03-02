using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcSpecialEndActTable : TableBase<EntityMBattleNpcSpecialEndAct>
    {
        private readonly Func<EntityMBattleNpcSpecialEndAct, (int,int,long,string)> primaryIndexSelector;

        public EntityMBattleNpcSpecialEndActTable(EntityMBattleNpcSpecialEndAct[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestSceneId,element.WaveNumber,element.BattleNpcId,element.BattleNpcDeckCharacterUuid);
        }
        
        public EntityMBattleNpcSpecialEndAct FindByQuestSceneIdAndWaveNumberAndBattleNpcIdAndBattleNpcDeckCharacterUuid(ValueTuple<int, int, long, string> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int,long,string)>.Default, key); }

    }
}
