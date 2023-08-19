using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleAttributeDamageCoefficientGroupTable : TableBase<EntityMBattleAttributeDamageCoefficientGroup>
{
    private readonly Func<EntityMBattleAttributeDamageCoefficientGroup, (int, AttributeType, AttributeType)> primaryIndexSelector;

    public EntityMBattleAttributeDamageCoefficientGroupTable(EntityMBattleAttributeDamageCoefficientGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.AttributeDamageCoefficientGroupId, element.SkillExecutorAttributeType, element.SkillTargetAttributeType);
    }
}
