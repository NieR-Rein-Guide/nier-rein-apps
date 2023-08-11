using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMTutorialDialogTable : TableBase<EntityMTutorialDialog>
{
    private readonly Func<EntityMTutorialDialog, TutorialType> primaryIndexSelector;

    public EntityMTutorialDialogTable(EntityMTutorialDialog[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.TutorialType;
    }

    public EntityMTutorialDialog FindByTutorialType(TutorialType key) => FindUniqueCore(data, primaryIndexSelector, Comparer<TutorialType>.Default, key);
}
