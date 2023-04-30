using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillCooltimeBehaviourOnFrameUpdateTable : TableBase<EntityMSkillCooltimeBehaviourOnFrameUpdate>
    {
        private readonly Func<EntityMSkillCooltimeBehaviourOnFrameUpdate, int> primaryIndexSelector;

        public EntityMSkillCooltimeBehaviourOnFrameUpdateTable(EntityMSkillCooltimeBehaviourOnFrameUpdate[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillCooltimeBehaviourActionId;
        }

        public bool TryFindBySkillCooltimeBehaviourActionId(int key, out EntityMSkillCooltimeBehaviourOnFrameUpdate result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
