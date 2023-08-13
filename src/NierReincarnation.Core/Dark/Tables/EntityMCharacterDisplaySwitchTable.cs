using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterDisplaySwitchTable : TableBase<EntityMCharacterDisplaySwitch>
{
    private readonly Func<EntityMCharacterDisplaySwitch, int> primaryIndexSelector;

    public EntityMCharacterDisplaySwitchTable(EntityMCharacterDisplaySwitch[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CharacterId;
    }

    public EntityMCharacterDisplaySwitch FindByCharacterId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
