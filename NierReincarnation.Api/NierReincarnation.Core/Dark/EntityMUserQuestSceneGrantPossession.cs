using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_user_quest_scene_grant_possession")]
public class EntityMUserQuestSceneGrantPossession
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public PossessionType PossessionType { get; set; }

    [Key(2)]
    public int PossessionId { get; set; }

    [Key(3)]
    public int Count { get; set; }

    [Key(4)]
    public bool IsGift { get; set; }

    [Key(5)]
    public bool IsDebug { get; set; }
}
