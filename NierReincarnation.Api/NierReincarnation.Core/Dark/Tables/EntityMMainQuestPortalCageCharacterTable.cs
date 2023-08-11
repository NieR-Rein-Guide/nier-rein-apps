using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMainQuestPortalCageCharacterTable : TableBase<EntityMMainQuestPortalCageCharacter>
{
    private readonly Func<EntityMMainQuestPortalCageCharacter, int> primaryIndexSelector;

    public EntityMMainQuestPortalCageCharacterTable(EntityMMainQuestPortalCageCharacter[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestSceneId;
    }
}
