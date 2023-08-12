using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcCharacterBoardStatusUpTable : TableBase<EntityMBattleNpcCharacterBoardStatusUp>
{
    private readonly Func<EntityMBattleNpcCharacterBoardStatusUp, (long, int, StatusCalculationType)> primaryIndexSelector;

    public EntityMBattleNpcCharacterBoardStatusUpTable(EntityMBattleNpcCharacterBoardStatusUp[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.CharacterId, element.StatusCalculationType);
    }
}
