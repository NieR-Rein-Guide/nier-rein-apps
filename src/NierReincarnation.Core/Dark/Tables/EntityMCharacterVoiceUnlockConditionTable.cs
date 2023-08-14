using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterVoiceUnlockConditionTable : TableBase<EntityMCharacterVoiceUnlockCondition>
{
    private readonly Func<EntityMCharacterVoiceUnlockCondition, (int, int)> primaryIndexSelector;

    public EntityMCharacterVoiceUnlockConditionTable(EntityMCharacterVoiceUnlockCondition[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CharacterId, element.SortOrder);
    }

    public EntityMCharacterVoiceUnlockCondition FindByCharacterIdAndSortOrder(ValueTuple<int, int> key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);
}
