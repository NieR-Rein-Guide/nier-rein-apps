using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleSkillBehaviourHitDamageConfigurationTable : TableBase<EntityMBattleSkillBehaviourHitDamageConfiguration>
{
    private readonly Func<EntityMBattleSkillBehaviourHitDamageConfiguration, (SkillCategoryType, int, int)> primaryIndexSelector;

    public EntityMBattleSkillBehaviourHitDamageConfigurationTable(EntityMBattleSkillBehaviourHitDamageConfiguration[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.SkillCategoryType, element.HitCount, element.HitIndexLowerLimit);
    }
}
