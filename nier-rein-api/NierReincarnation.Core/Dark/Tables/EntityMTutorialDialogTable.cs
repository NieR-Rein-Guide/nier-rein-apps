using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTutorialDialogTable : TableBase<EntityMTutorialDialog>
    {
        private readonly Func<EntityMTutorialDialog, int> primaryIndexSelector;

        public EntityMTutorialDialogTable(EntityMTutorialDialog[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.TutorialType;
        }
        
        public EntityMTutorialDialog FindByTutorialType(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
