using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestReleaseConditionWeaponAcquisitionTable : TableBase<EntityMQuestReleaseConditionWeaponAcquisition>
{
    private readonly Func<EntityMQuestReleaseConditionWeaponAcquisition, int> primaryIndexSelector;

    public EntityMQuestReleaseConditionWeaponAcquisitionTable(EntityMQuestReleaseConditionWeaponAcquisition[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestReleaseConditionId;
    }

    public EntityMQuestReleaseConditionWeaponAcquisition FindByQuestReleaseConditionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
