using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAnimationStepTable : TableBase<EntityMCostumeAnimationStep>
    {
        private readonly Func<EntityMCostumeAnimationStep, (int, int, int)> primaryIndexSelector;

        public EntityMCostumeAnimationStepTable(EntityMCostumeAnimationStep[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeId, element.Step, element.ActorAnimationId);
        }
    }
}
