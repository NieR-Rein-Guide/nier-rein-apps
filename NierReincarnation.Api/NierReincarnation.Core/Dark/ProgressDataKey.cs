namespace NierReincarnation.Core.Dark;

[MessagePackObject]
public class ProgressDataKey
{
    [Key(0)]
    public int Key0 { set; get; }

    [Key(1)]
    public int Key1 { set; get; }

    [Key(2)]
    public int Key2 { set; get; }
}
