using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCageOrnamentMainQuestChapterStillTable : TableBase<EntityMCageOrnamentMainQuestChapterStill>
{
    private readonly Func<EntityMCageOrnamentMainQuestChapterStill, int> primaryIndexSelector;

    public EntityMCageOrnamentMainQuestChapterStillTable(EntityMCageOrnamentMainQuestChapterStill[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MainQuestChapterId;
    }

    public EntityMCageOrnamentMainQuestChapterStill FindByMainQuestChapterId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
