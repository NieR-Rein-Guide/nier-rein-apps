using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardPanelReleaseRewardGroupTable : TableBase<EntityMCharacterBoardPanelReleaseRewardGroup>
    {
        private readonly Func<EntityMCharacterBoardPanelReleaseRewardGroup, (int, PossessionType, int)> primaryIndexSelector;

        public EntityMCharacterBoardPanelReleaseRewardGroupTable(EntityMCharacterBoardPanelReleaseRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CharacterBoardPanelReleaseRewardGroupId, element.PossessionType, element.PossessionId);
        }
    }
}
