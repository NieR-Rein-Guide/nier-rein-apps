using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcWeaponNoteTable : TableBase<EntityMBattleNpcWeaponNote>
{
    private readonly Func<EntityMBattleNpcWeaponNote, (long, int)> primaryIndexSelector;

    public EntityMBattleNpcWeaponNoteTable(EntityMBattleNpcWeaponNote[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.WeaponId);
    }
}
