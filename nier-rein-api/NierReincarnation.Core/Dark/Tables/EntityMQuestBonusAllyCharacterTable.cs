using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusAllyCharacterTable : TableBase<EntityMQuestBonusAllyCharacter>
    {
        private readonly Func<EntityMQuestBonusAllyCharacter, int> primaryIndexSelector;

        public EntityMQuestBonusAllyCharacterTable(EntityMQuestBonusAllyCharacter[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestBonusAllyCharacterId;
        }

        public bool TryFindByQuestBonusAllyCharacterId(int key, out EntityMQuestBonusAllyCharacter result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }
    }
}
