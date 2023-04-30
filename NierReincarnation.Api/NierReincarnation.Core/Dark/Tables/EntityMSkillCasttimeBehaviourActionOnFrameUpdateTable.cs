using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillCasttimeBehaviourActionOnFrameUpdateTable : TableBase<EntityMSkillCasttimeBehaviourActionOnFrameUpdate>
    {
        private readonly Func<EntityMSkillCasttimeBehaviourActionOnFrameUpdate, int> primaryIndexSelector;

        public EntityMSkillCasttimeBehaviourActionOnFrameUpdateTable(EntityMSkillCasttimeBehaviourActionOnFrameUpdate[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillCasttimeBehaviourActionId;
        }

        public bool TryFindBySkillCasttimeBehaviourActionId(int key, out EntityMSkillCasttimeBehaviourActionOnFrameUpdate result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
