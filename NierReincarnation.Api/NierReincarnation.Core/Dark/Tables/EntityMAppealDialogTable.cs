using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

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

        public RangeView<EntityMAppealDialog> FindByAppealTargetType(AppealTargetType key) { return FindManyCore(data, secondaryIndexSelector, Comparer<AppealTargetType>.Default, key); }

    }
}