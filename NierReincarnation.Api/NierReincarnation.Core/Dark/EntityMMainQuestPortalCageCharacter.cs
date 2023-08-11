using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_main_quest_portal_cage_character")]
    public class EntityMMainQuestPortalCageCharacter
    {
        [Key(0)]
        public int QuestSceneId { get; set; }

        [Key(1)]
        public int PortalCageCharacterGroupId { get; set; }
    }
}
