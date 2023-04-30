using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcWeaponNoteReevaluateTable : TableBase<EntityMBattleNpcWeaponNoteReevaluate>
    {
        private readonly Func<EntityMBattleNpcWeaponNoteReevaluate, long> primaryIndexSelector;

        public EntityMBattleNpcWeaponNoteReevaluateTable(EntityMBattleNpcWeaponNoteReevaluate[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleNpcId;
        }
    }
}
