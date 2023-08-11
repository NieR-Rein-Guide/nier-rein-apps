using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestChapterCharacterTable : TableBase<EntityMEventQuestChapterCharacter>
{
    private readonly Func<EntityMEventQuestChapterCharacter, int> primaryIndexSelector;

    public EntityMEventQuestChapterCharacterTable(EntityMEventQuestChapterCharacter[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.EventQuestChapterId;
    }

    public EntityMEventQuestChapterCharacter FindByEventQuestChapterId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
