using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestBonusExpTable : TableBase<EntityMQuestBonusExp>
{
    private readonly Func<EntityMQuestBonusExp, int> primaryIndexSelector;

    public EntityMQuestBonusExpTable(EntityMQuestBonusExp[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestBonusEffectId;
    }

    public EntityMQuestBonusExp FindByQuestBonusEffectId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
