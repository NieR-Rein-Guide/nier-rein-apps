using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionDefaultSkillLotteryTable : TableBase<EntityMSkillBehaviourActionDefaultSkillLottery>
{
    private readonly Func<EntityMSkillBehaviourActionDefaultSkillLottery, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionDefaultSkillLotteryTable(EntityMSkillBehaviourActionDefaultSkillLottery[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionDefaultSkillLottery FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
