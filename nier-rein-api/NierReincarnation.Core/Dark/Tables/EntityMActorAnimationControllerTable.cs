using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMActorAnimationControllerTable : TableBase<EntityMActorAnimationController>
    {
        private readonly Func<EntityMActorAnimationController, int> primaryIndexSelector;

        public EntityMActorAnimationControllerTable(EntityMActorAnimationController[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ActorAnimationControllerId;
        }
        
    }
}
