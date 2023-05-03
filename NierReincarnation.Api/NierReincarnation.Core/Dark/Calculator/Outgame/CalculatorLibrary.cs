using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorLibrary
    {
        private const int kLibraryMovieUnlockConditionId = 0;
        private const int kFirstStillOrder = 1;
        private const int kSecondStillOrder = 2;
        private const int kMaxSeasonCount = 8;
        private const int kMinLibraryStoryQuestCount = 1;
        private const int kMaxLibraryStoryQuestCount = 4;
        private const int kCapacityStringBuilder = 40;
        private const string kMvFileName = "{0}{1:D2}{2}.mp4";
        private const string kRecordTitle = "record.title.name.{0:D3}";
        private const string kReportTitle = "report.library.title.{0:D6}";
        private const string kCageMemoryTitle = "cage.memory.library.title.{0:D6}";
        private const string kRecordThumbnailPath = "ui)library)record)record{0:D3}";
        private const string kReportThumbnailPath = "ui)library)report){0:D6})report{0:D6}_standard";
        private const string kCageMemoryThumbnailPath = "ui)library)cage_memory){0:D6})cage_memory{0:D6}_standard";

        private static string GetEventStoryTextKey(int eventQuestType, int chapterSortOrder, int questSortOrder) =>
            $"quest.event.chapter.story.{eventQuestType:D2}.{chapterSortOrder:D4}.{questSortOrder:D4}";

        private static string GetContentsStoryTextKey(int eventMapNumberUpper, int eventMapNumberLower) =>
            $"content.story.{eventMapNumberUpper:D7}.{eventMapNumberLower:D6}";

        private static string GetLimitContentStoryTextKey(int questId) => $"limit.content.story.{questId:D7}";

        private static string GetMainStoryTextKey(int seasonId, int chapterId, int questId) => $"story.Main.Quest.{seasonId:D4}.{chapterId:D4}.{questId:D4}";

        private static string GetMainStoryTextKey(int seasonId, int chapterId, int questId, int textAssetId) =>
            $"story.Main.Quest.{seasonId:D4}.{chapterId:D4}.{questId:D4}.{textAssetId}";

        public static bool IsUnlockFirstStill() => true;

        //public static bool IsUnlockSecondStill(int mainQuestChapterId)
        //{
        //    return CalculatorMainQuest.IsClearMainQuestChapter(mainQuestChapterId, DifficultyType.NORMAL, CalculatorStateUser.GetUserId());
        //}

        public static bool IsUnlockEndContentsLibrary() => CalculatorUnlockCondition.IsUnlockEndContents();

        //public static bool IsUnlockLimitContentLibrary()
        //{
        //    return CalculatorLimitContent.IsClearFirstNormalLevelByLimitContents(CalculatorStateUser.GetUserId());
        //}

        private static bool IsUnlockEvent(int eventQuestChapterId) => CalculatorQuest.HasClearedQuestInEventChapter(eventQuestChapterId);

        //private static bool IsUnlockEndCharacter(int endWeaponId)
        //{
        //    return CalculatorWeapon.HadWeapon(CalculatorStateUser.GetUserId(), endWeaponId);
        //}

        private static bool IsUnlockEventStory(int questId) => CalculatorQuest.IsClearQuest(questId);

        private static bool IsUnlockEndStory(int contentsStoryId) => CalculatorEndContents.IsAlreadyViewStory(contentsStoryId);

        private static string GetEventStoryBackgroundPath(int eventQuestType, int chapterSortOrder, int questSortOrder) =>
            $"ui)library)event_quest_type_{eventQuestType:D2})bg{chapterSortOrder:D4}{questSortOrder:D4}";

        private static string GetEndContentsStoryBackgroundPath(int eventMapNumberUpper, int eventMapNumberLower) =>
            $"ui)library)content)bg{eventMapNumberUpper:D7}{eventMapNumberLower:D6}";

        public static string GetLimitContentStoryBackgroundPath(int questId) => $"ui)library)limit_content)bg{questId:D7}";

        private static string CreateMovieFileNamePrefix(int mainQuestSeasonSortOrder, int mainQuestRouteSortOrder, int mainQuestChapterSortOrder) =>
            $"mm{mainQuestSeasonSortOrder:D2}{mainQuestRouteSortOrder:D2}{mainQuestChapterSortOrder:D2}";
    }
}
