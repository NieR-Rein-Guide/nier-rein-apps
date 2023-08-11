namespace NierReincarnation.Core.Dark.View.UserInterface;

public class CharacterQuestChapterData
{
   
    public int EventQuestChapterId { get; set; }
   
    public int CharacterId { get; set; }
    //public EventQuestType EventQuestType { set; }
   
    public string EventQuestName { get; set; }

    // CUSTOM: If chapter is available
    public bool IsLock { get; set; }
}
