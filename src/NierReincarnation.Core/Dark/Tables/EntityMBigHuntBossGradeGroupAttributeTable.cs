using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBigHuntBossGradeGroupAttributeTable : TableBase<EntityMBigHuntBossGradeGroupAttribute>
{
    private readonly Func<EntityMBigHuntBossGradeGroupAttribute, int> primaryIndexSelector;

    public EntityMBigHuntBossGradeGroupAttributeTable(EntityMBigHuntBossGradeGroupAttribute[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AttributeType;
    }
}
