namespace NierReincarnation.Core.Dark.View.UserInterface
{
    public class CharacterQuestChapterData
    {
        // 0x10
        public int EventQuestChapterId { get; set; }
        // 0x14
        public int CharacterId { get; set; }
        //public EventQuestType EventQuestType { set; }
        // 0x20
        public string EventQuestName { get; set; }

        // CUSTOM: If chapter is available
        public bool IsLock { get; set; }
    }
}
