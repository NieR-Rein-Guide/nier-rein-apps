using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionHpRatioDamageTable : TableBase<EntityMSkillBehaviourActionHpRatioDamage>
{
    private readonly Func<EntityMSkillBehaviourActionHpRatioDamage, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionHpRatioDamageTable(EntityMSkillBehaviourActionHpRatioDamage[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionHpRatioDamage FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
