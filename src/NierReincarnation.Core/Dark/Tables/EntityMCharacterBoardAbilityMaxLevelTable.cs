using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterBoardAbilityMaxLevelTable : TableBase<EntityMCharacterBoardAbilityMaxLevel>
{
    private readonly Func<EntityMCharacterBoardAbilityMaxLevel, (int, int)> primaryIndexSelector;

    public EntityMCharacterBoardAbilityMaxLevelTable(EntityMCharacterBoardAbilityMaxLevel[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CharacterId, element.AbilityId);
    }

    public EntityMCharacterBoardAbilityMaxLevel FindByCharacterIdAndAbilityId(ValueTuple<int, int> key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);
}
