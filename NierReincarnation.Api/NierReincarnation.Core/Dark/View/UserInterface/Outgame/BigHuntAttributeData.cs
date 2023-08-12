using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public sealed class BigHuntAttributeData
{
    public AttributeType AttributeType { get; set; }

    public long BeforeScore { get; set; }

    public long AfterScore { get; set; }

    public long CurrentScore { get; set; }

    public int BeforeAssetGradeIconId { get; set; }

    public int AfterAssetGradeIconId { get; set; }

    public int CurrentAssetGradeIconId { get; set; }
}
