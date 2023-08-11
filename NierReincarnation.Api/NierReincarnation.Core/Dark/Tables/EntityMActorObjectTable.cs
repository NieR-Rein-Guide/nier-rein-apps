using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMActorObjectTable : TableBase<EntityMActorObject>
{
    private readonly Func<EntityMActorObject, int> primaryIndexSelector;

    public EntityMActorObjectTable(EntityMActorObject[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ActorObjectId;
    }

    public EntityMActorObject FindByActorObjectId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
