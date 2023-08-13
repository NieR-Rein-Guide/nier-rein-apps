using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterViewerFieldTable : TableBase<EntityMCharacterViewerField>
{
    private readonly Func<EntityMCharacterViewerField, int> primaryIndexSelector;

    public EntityMCharacterViewerFieldTable(EntityMCharacterViewerField[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CharacterViewerFieldId;
    }

    public EntityMCharacterViewerField FindByCharacterViewerFieldId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
