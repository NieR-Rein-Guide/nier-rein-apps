using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMActorAnimationTable : TableBase<EntityMActorAnimation>
    {
        private readonly Func<EntityMActorAnimation, int> primaryIndexSelector;

        public EntityMActorAnimationTable(EntityMActorAnimation[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ActorAnimationId;
        }
        
        public EntityMActorAnimation FindByActorAnimationId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
