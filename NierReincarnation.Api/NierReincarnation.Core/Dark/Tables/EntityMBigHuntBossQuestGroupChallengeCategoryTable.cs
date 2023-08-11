using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBigHuntBossQuestGroupChallengeCategoryTable : TableBase<EntityMBigHuntBossQuestGroupChallengeCategory>
{
    private readonly Func<EntityMBigHuntBossQuestGroupChallengeCategory, (int, int)> primaryIndexSelector;

    public EntityMBigHuntBossQuestGroupChallengeCategoryTable(EntityMBigHuntBossQuestGroupChallengeCategory[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BigHuntBossQuestGroupChallengeCategoryId, element.SortOrder);
    }
}
