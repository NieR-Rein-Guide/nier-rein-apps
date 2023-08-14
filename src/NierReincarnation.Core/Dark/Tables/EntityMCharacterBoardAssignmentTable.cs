using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterBoardAssignmentTable : TableBase<EntityMCharacterBoardAssignment>
{
    private readonly Func<EntityMCharacterBoardAssignment, int> primaryIndexSelector;

    public EntityMCharacterBoardAssignmentTable(EntityMCharacterBoardAssignment[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CharacterId;
    }

    public EntityMCharacterBoardAssignment FindByCharacterId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
