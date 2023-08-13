using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSpeakerTable : TableBase<EntityMSpeaker>
{
    private readonly Func<EntityMSpeaker, int> primaryIndexSelector;

    public EntityMSpeakerTable(EntityMSpeaker[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ActorObjectId;
    }

    public EntityMSpeaker FindByActorObjectId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
