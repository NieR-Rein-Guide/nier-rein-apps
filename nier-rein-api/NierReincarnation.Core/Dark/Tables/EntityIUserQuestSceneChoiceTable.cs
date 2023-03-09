using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NierReincarnation.Core.Dark.Tables
{
    public sealed class EntityIUserQuestSceneChoiceTable : TableBase<EntityIUserQuestSceneChoice>
    {
        private readonly Func<EntityIUserQuestSceneChoice, (long, int)> primaryIndexSelector; // 0x18

        public EntityIUserQuestSceneChoiceTable(EntityIUserQuestSceneChoice[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = choice => (choice.UserId, choice.QuestSceneChoiceGroupingId);
        }

        public EntityIUserQuestSceneChoice FindByUserIdAndQuestSceneChoiceGroupingId((long, int) key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
        }

        public bool TryFindByUserIdAndQuestSceneChoiceGroupingId((long, int) key, out EntityIUserQuestSceneChoice result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result);
        }
    }
}
