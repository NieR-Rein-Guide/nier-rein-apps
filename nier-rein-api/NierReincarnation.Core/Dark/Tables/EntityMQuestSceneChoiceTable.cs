using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestSceneChoiceTable : TableBase<EntityMQuestSceneChoice>
    {
        private readonly Func<EntityMQuestSceneChoice, (int, QuestFlowType, int)> primaryIndexSelector;

        public EntityMQuestSceneChoiceTable(EntityMQuestSceneChoice[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.MainFlowQuestSceneId, element.QuestFlowType, element.ChoiceNumber);
        }
    }
}
