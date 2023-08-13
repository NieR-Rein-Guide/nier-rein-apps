using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMDokanTable : TableBase<EntityMDokan>
{
    private readonly Func<EntityMDokan, int> primaryIndexSelector;

    public EntityMDokanTable(EntityMDokan[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.DokanId;
    }
}
