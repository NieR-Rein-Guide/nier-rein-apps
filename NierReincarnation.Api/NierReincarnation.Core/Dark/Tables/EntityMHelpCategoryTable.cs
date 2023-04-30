using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMHelpCategoryTable : TableBase<EntityMHelpCategory>
    {
        private readonly Func<EntityMHelpCategory, int> primaryIndexSelector;

        public EntityMHelpCategoryTable(EntityMHelpCategory[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.HelpCategoryId;
        }
    }
}
