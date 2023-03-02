using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMImportantItemEffectTargetQuestGroupTable : TableBase<EntityMImportantItemEffectTargetQuestGroup>
    {
        private readonly Func<EntityMImportantItemEffectTargetQuestGroup, (int,int)> primaryIndexSelector;

        public EntityMImportantItemEffectTargetQuestGroupTable(EntityMImportantItemEffectTargetQuestGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.ImportantItemEffectTargetQuestGroupId,element.TargetIndex);
        }
        
    }
}
