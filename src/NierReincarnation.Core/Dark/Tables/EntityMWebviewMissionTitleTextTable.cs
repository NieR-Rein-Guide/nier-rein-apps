using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMWebviewMissionTitleTextTable : TableBase<EntityMWebviewMissionTitleText>
{
    private readonly Func<EntityMWebviewMissionTitleText, (int, LanguageType)> primaryIndexSelector;

    public EntityMWebviewMissionTitleTextTable(EntityMWebviewMissionTitleText[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.WebviewMissionTitleTextId, element.LanguageType);
    }

    public EntityMWebviewMissionTitleText FindByWebviewMissionTitleTextIdAndLanguageType(ValueTuple<int, LanguageType> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(int, LanguageType)>.Default, key);
}
