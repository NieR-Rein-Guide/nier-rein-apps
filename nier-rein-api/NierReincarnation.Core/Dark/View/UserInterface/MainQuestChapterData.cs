using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface
{
    // CUSTOM: Emulates EventQuestChapterData to represent main quest chapters
    public class MainQuestChapterData
    {
        // 0x10
        public int MainQuestChapterId { get; set; }
        // 0x18
        public string MainQuestChapterName { get; set; }
        // 0x20
        public string MainQuestChapterNumberName { get; set; }
        // 0x28
        public List<DifficultyType> MainQuestChapterDifficultyTypes { get; set; }
    }
}
