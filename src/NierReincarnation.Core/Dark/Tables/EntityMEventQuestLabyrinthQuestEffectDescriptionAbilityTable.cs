using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestLabyrinthQuestEffectDescriptionAbilityTable : TableBase<EntityMEventQuestLabyrinthQuestEffectDescriptionAbility>
{
    private readonly Func<EntityMEventQuestLabyrinthQuestEffectDescriptionAbility, int> primaryIndexSelector;

    public EntityMEventQuestLabyrinthQuestEffectDescriptionAbilityTable(EntityMEventQuestLabyrinthQuestEffectDescriptionAbility[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.EventQuestLabyrinthQuestEffectDescriptionId;
    }

    public EntityMEventQuestLabyrinthQuestEffectDescriptionAbility FindByEventQuestLabyrinthQuestEffectDescriptionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
