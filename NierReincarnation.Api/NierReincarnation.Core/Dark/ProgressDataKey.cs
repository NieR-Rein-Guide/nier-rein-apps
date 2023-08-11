using MessagePack;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
public class ProgressDataKey
{
    [Key(0)] // RVA: 0x1DD627C Offset: 0x1DD627C VA: 0x1DD627C
    public int Key0 { set; get; }
    [Key(1)] // RVA: 0x1DD6290 Offset: 0x1DD6290 VA: 0x1DD6290
    public int Key1 { set; get; }
    [Key(2)] // RVA: 0x1DD62A4 Offset: 0x1DD62A4 VA: 0x1DD62A4
    public int Key2 { set; get; }
}
