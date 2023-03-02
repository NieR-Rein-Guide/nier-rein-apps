using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public sealed class DataLimitContentCharacter
    {
        public int EventQuestLimitContentId { get; set; }
        public DataOutgameCostume Costume { get; set; }
        public int SortOrder { get; set; }
        public Dictionary<DifficultyType, DataLimitContentLevelClearProgress> LevelClearProgresses { get; set; }
        public bool IsLock { get; set; }
        public string LockText { get; set; }
        public string BackgroundImagePath { get; set; }
        public string FullSizeBackgroundImagePath { get; set; }
        public bool IsCostumeAcquired { get; set; }
	}
}
