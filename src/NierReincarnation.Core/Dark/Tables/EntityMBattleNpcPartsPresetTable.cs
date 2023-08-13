using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcPartsPresetTable : TableBase<EntityMBattleNpcPartsPreset>
{
    private readonly Func<EntityMBattleNpcPartsPreset, (long, int)> primaryIndexSelector;

    public EntityMBattleNpcPartsPresetTable(EntityMBattleNpcPartsPreset[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcPartsPresetNumber);
    }
}
