using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestSceneNotConfirmTitleDialogTable : TableBase<EntityMQuestSceneNotConfirmTitleDialog>
    {
        private readonly Func<EntityMQuestSceneNotConfirmTitleDialog, int> primaryIndexSelector;

        public EntityMQuestSceneNotConfirmTitleDialogTable(EntityMQuestSceneNotConfirmTitleDialog[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestSceneId;
        }

        public EntityMQuestSceneNotConfirmTitleDialog FindByQuestSceneId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
