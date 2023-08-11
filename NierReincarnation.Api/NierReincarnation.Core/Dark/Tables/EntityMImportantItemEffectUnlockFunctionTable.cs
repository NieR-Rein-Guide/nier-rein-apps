using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMImportantItemEffectUnlockFunctionTable : TableBase<EntityMImportantItemEffectUnlockFunction>
{
    private readonly Func<EntityMImportantItemEffectUnlockFunction, int> primaryIndexSelector;

    public EntityMImportantItemEffectUnlockFunctionTable(EntityMImportantItemEffectUnlockFunction[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ImportantItemEffectUnlockFunctionId;
    }
}
