using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardPanelReleaseRewardGroupTable : TableBase<EntityMCharacterBoardPanelReleaseRewardGroup>
    {
        private readonly Func<EntityMCharacterBoardPanelReleaseRewardGroup, (int,int,int)> primaryIndexSelector;

        public EntityMCharacterBoardPanelReleaseRewardGroupTable(EntityMCharacterBoardPanelReleaseRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CharacterBoardPanelReleaseRewardGroupId,element.PossessionType,element.PossessionId);
        }
        
    }
}
