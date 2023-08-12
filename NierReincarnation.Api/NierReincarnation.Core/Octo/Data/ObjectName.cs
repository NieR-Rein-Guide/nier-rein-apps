namespace NierReincarnation.Core.Octo.Data;

public struct ObjectName
{
    private static readonly Encoding ascii = Encoding.ASCII;

    private byte b0;
    private byte b1;
    private byte b2;
    private byte b3;
    private byte b4;
    private byte b5;

    public void Set(string name)
    {
        if (name == null || name.Length != 6) return;

        var data = ascii.GetBytes(name);

        b0 = data[0];
        b1 = data[1];
        b2 = data[2];
        b3 = data[3];
        b4 = data[4];
        b5 = data[5];
    }

    public override readonly string ToString() => ascii.GetString(new[] { b0, b1, b2, b3, b4, b5 });

    public readonly string ToHexString() => $"{b0:X}{b1:X}{b1:X}{b2:X}{b3:X}{b4:X}{b5:X}";
}
