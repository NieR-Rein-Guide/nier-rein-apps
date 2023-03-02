using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorOutgame
    {
        public static RarityType PreciousRarityThreshold = RarityType.SS_RARE; // 0x0
        public static readonly int kMinDifficulty = 1; // 0x4
        public static readonly int kMaxDifficulty = 4; // 0x8
        public static readonly List<DifficultyType> kSortedDifficulties = new List<DifficultyType>
        {
            DifficultyType.NORMAL,
            DifficultyType.HARD,
            DifficultyType.VERY_HARD,
            DifficultyType.EX_HARD
        }; // 0x10
        public static readonly string kGradeIconPrefabKeyPrefix = "ui.rank_icon.prefab."; // 0x18
        private static readonly string kGradeIconSpriteAssetPathFormat = "ui)search)rank)search_rank_{0}"; // 0x20
        private static readonly string kGradeIconPrefabAssetPathFormat = "ui)rank)rank_icon_{0})rank_icon_{0}"; // 0x28
        private static readonly string kGradeIconLargePrefabAssetPathFormat = "ui)rank)rank_icon_{0}_large)rank_icon_{0}_large"; // 0x30
        private static readonly string kGradeIconPrefabKeyFormat = kGradeIconPrefabKeyPrefix + "{0}"; // 0x38
        private static readonly string kGradeIconLargePrefabKeyFormat = kGradeIconPrefabKeyPrefix + ".large.{0}"; // 0x40
    }
}
