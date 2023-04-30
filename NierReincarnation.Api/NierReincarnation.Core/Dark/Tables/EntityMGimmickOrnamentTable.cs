using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMGimmickOrnamentTable : TableBase<EntityMGimmickOrnament>
    {
        private readonly Func<EntityMGimmickOrnament, (int, int)> primaryIndexSelector;

        public EntityMGimmickOrnamentTable(EntityMGimmickOrnament[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.GimmickOrnamentGroupId, element.GimmickOrnamentIndex);
        }
    }
}
