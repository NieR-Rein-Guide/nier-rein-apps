using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterBoardCategoryTable : TableBase<EntityMCharacterBoardCategory>
{
    private readonly Func<EntityMCharacterBoardCategory, int> primaryIndexSelector;

    public EntityMCharacterBoardCategoryTable(EntityMCharacterBoardCategory[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CharacterBoardCategoryId;
    }

    public EntityMCharacterBoardCategory FindByCharacterBoardCategoryId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
