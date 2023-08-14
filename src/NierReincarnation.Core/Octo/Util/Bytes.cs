namespace NierReincarnation.Core.Octo.Util;

internal static class Bytes
{
    public static byte[] StringToByteArray(string text) => Encoding.UTF8.GetBytes(text);

    public static byte[] ReverseIfNotLittleEndian(byte[] data)
    {
        if (!BitConverter.IsLittleEndian)
            Array.Reverse(data);

        return data;
    }

    public static bool ByteArrayEqual(byte[] data1, byte[] data2)
    {
        if (data1 == data2)
            return true;

        if (data1 == null)
            return false;

        if (data2 == null)
            return false;

        if (data1.Length != data2.Length)
            return false;

        // Note: Original code re-implements a loop to compare every byte. Let's not re-invent the wheel too much, ok?
        return data1.SequenceEqual(data2);
    }

    public static byte[] CombineArrays(byte[] data1, byte[] data2)
    {
        if (data1 == null || data2 == null)
        {
            throw new ArgumentNullException();
        }

        var buffer = new byte[data1.Length + data2.Length];
        Buffer.BlockCopy(data1, 0, buffer, 0, data1.Length);
        Buffer.BlockCopy(data2, 0, buffer, data1.Length, data2.Length);

        return buffer;
    }
}
