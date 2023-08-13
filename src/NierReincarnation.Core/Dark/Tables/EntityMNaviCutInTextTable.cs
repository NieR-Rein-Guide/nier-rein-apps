using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMNaviCutInTextTable : TableBase<EntityMNaviCutInText>
{
    private readonly Func<EntityMNaviCutInText, (int, LanguageType)> primaryIndexSelector;

    public EntityMNaviCutInTextTable(EntityMNaviCutInText[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.NaviCutInTextId, element.LanguageType);
    }

    public EntityMNaviCutInText FindByNaviCutInTextIdAndLanguageType(ValueTuple<int, LanguageType> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(int, LanguageType)>.Default, key);
}
