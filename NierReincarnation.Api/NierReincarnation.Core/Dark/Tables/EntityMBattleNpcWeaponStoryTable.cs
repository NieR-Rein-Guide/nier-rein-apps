using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcWeaponStoryTable : TableBase<EntityMBattleNpcWeaponStory>
    {
        private readonly Func<EntityMBattleNpcWeaponStory, (long, int)> primaryIndexSelector;

        public EntityMBattleNpcWeaponStoryTable(EntityMBattleNpcWeaponStory[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId, element.WeaponId);
        }
    }
}
