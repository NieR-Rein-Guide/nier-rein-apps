using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAppealDialogTable : TableBase<EntityMAppealDialog>
    {
        private readonly Func<EntityMAppealDialog, int> primaryIndexSelector;
        private readonly Func<EntityMAppealDialog, AppealTargetType> secondaryIndexSelector;

        public EntityMAppealDialogTable(EntityMAppealDialog[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.AppealDialogId;
            secondaryIndexSelector = element => element.AppealTargetType;
        }

        public RangeView<EntityMAppealDialog> FindByAppealTargetType(AppealTargetType key) => FindManyCore(data, secondaryIndexSelector, Comparer<AppealTargetType>.Default, key);
    }
}
