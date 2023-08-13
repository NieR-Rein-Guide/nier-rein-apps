using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMDokanContentGroupTable : TableBase<EntityMDokanContentGroup>
{
    private readonly Func<EntityMDokanContentGroup, (int, int)> primaryIndexSelector;

    public EntityMDokanContentGroupTable(EntityMDokanContentGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.DokanContentGroupId, element.ContentIndex);
    }
}
