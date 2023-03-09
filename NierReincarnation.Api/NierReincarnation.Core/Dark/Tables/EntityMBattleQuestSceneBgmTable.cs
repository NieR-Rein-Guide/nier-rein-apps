using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBattleQuestSceneBgmTable : TableBase<EntityMBattleQuestSceneBgm> // TypeDefIndex: 11687
    {
        // Fields
        private readonly Func<EntityMBattleQuestSceneBgm, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C49800 Offset: 0x2C49800 VA: 0x2C49800
        public EntityMBattleQuestSceneBgmTable(EntityMBattleQuestSceneBgm[] sortedData):base(sortedData)
        {
            primaryIndexSelector = bgm => (bgm.QuestSceneId, bgm.StartWaveNumber);
        }
    }
}
