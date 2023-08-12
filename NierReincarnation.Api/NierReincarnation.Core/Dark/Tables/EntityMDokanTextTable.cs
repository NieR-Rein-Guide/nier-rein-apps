using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMDokanTextTable : TableBase<EntityMDokanText>
{
    private readonly Func<EntityMDokanText, (int, LanguageType)> primaryIndexSelector;

    public EntityMDokanTextTable(EntityMDokanText[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.DokanTextId, element.LanguageType);
    }

    public EntityMDokanText FindByDokanTextIdAndLanguageType(ValueTuple<int, LanguageType> key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(int, LanguageType)>.Default, key);
}
