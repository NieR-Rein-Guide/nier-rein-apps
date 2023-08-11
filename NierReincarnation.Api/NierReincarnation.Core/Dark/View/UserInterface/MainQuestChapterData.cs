using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface
{
    // CUSTOM: Emulates EventQuestChapterData to represent main quest chapters
    public class MainQuestChapterData
    {
       
        public int MainQuestChapterId { get; set; }
       
        public string MainQuestChapterName { get; set; }
       
        public string MainQuestChapterNumberName { get; set; }
       
        public List<DifficultyType> MainQuestChapterDifficultyTypes { get; set; }
    }
}
