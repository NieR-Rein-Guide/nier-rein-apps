using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestGuerrillaFreeOpenTable : TableBase<EntityMEventQuestGuerrillaFreeOpen>
{
    private readonly Func<EntityMEventQuestGuerrillaFreeOpen, int> primaryIndexSelector;

    public EntityMEventQuestGuerrillaFreeOpenTable(EntityMEventQuestGuerrillaFreeOpen[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.EventQuestGuerrillaFreeOpenId;
    }
}
