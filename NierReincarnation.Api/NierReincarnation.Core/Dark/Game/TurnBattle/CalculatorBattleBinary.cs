using NierReincarnation.Core.Dark.Game.TurnBattle.Types;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

public static class CalculatorBattleBinary
{
    private static byte[] _battleBinaryPool;

    private static byte[] _snapshotBinaryPool;
    private static byte[] _checksumBinaryPool;
    private const int BinaryPoolSize = 0x2000;
    private static MemoryStream _streamBattleBinaryPool;
    private const int VersionBinaryLength = 4;
    private const int ChecksumBinaryLength = 4;
    private const int SuccessFlagBinaryLength = 1;

    private static MemoryStream StreamBattleBinaryPool => _streamBattleBinaryPool ??= new MemoryStream(BinaryPoolSize);

    private static byte[] BattleBinaryPool => _battleBinaryPool ??= new byte[BinaryPoolSize];

    private static byte[] SnapshotBinaryPool => _snapshotBinaryPool ??= new byte[BinaryPoolSize];

    private static byte[] ChecksumBinaryPool => _checksumBinaryPool ??= new byte[ChecksumBinaryLength];

    public static bool DeserializeBattleBinary(byte[] battleBinary, out TurnBattleSnapshot snapshot, CancellationToken cxlToken)
    {
        if (!CheckIsValid(battleBinary, out _, out _, out _))
        {
            snapshot = null;
            return false;
        }

        var headerSize = VersionBinaryLength + ChecksumBinaryLength + SuccessFlagBinaryLength;

        var snapshotPool = SnapshotBinaryPool;
        FlushBinary(snapshotPool);

        Array.Copy(battleBinary, headerSize, snapshotPool, 0, battleBinary.Length - headerSize);

        snapshot = MessagePackSerializer.Deserialize<TurnBattleSnapshot>(snapshotPool, null, cxlToken);
        return true;
    }

    public static bool CheckIsValid(byte[] battleBinary, out bool isValidVersion, out bool isValidChecksum, out bool isDataStoreSuccess)
    {
        isValidVersion = VersionCheck(battleBinary);
        isValidChecksum = CheckSum(battleBinary);
        isDataStoreSuccess = IsDataStoreSuccess(battleBinary);

        return isValidVersion & isValidChecksum & isDataStoreSuccess;
    }

    public static bool VersionCheck(byte[] battleBinary)
    {
        return BitConverter.ToInt32(battleBinary, SuccessFlagBinaryLength) == BattleProgressDataDefinition.kTurnBattleSnapshotVersion;
    }

    public static bool CheckSum(byte[] battleBinary)
    {
        var checksumPool = ChecksumBinaryPool;
        FlushBinary(checksumPool);

        Array.Copy(battleBinary, VersionBinaryLength + SuccessFlagBinaryLength, checksumPool, 0, ChecksumBinaryLength);

        var checksum = BitConverter.ToInt32(checksumPool, 0);

        var headerSize = VersionBinaryLength + ChecksumBinaryLength + SuccessFlagBinaryLength;
        var checksumBinary = GetChecksumBinary(battleBinary, headerSize, battleBinary.Length - headerSize);

        return checksum == BitConverter.ToInt32(checksumBinary, 0);
    }

    public static bool IsDataStoreSuccess(byte[] battleBinary)
    {
        return BitConverter.ToBoolean(battleBinary, 0);
    }

    public static byte[] CreateBattleBinary(TurnBattleSnapshot snapshot, CancellationToken cxlToken, out int binarySize)
    {
        var poolStream = StreamBattleBinaryPool;
        poolStream.Position = 0;

        MessagePackSerializer.Serialize(poolStream, snapshot, null, cxlToken);
        var battleBinary = poolStream.ToArray()[..(int)poolStream.Position];

        var isSuccess = VersionBinaryLength + ChecksumBinaryLength + SuccessFlagBinaryLength + battleBinary.Length <= BinaryPoolSize;
        var successBinary = GetSuccessFlagBinary(isSuccess);
        var versionBinary = GetBattleBinaryVersionBinary();
        var checksumBinary = GetChecksumBinary(battleBinary, 0, battleBinary.Length);

        var binaryPool = BattleBinaryPool;
        FlushBinary(binaryPool);

        Array.Copy(successBinary, 0, binaryPool, 0, SuccessFlagBinaryLength);
        if (isSuccess)
        {
            Array.Copy(versionBinary, 0, binaryPool, SuccessFlagBinaryLength, VersionBinaryLength);
            Array.Copy(checksumBinary, 0, binaryPool, VersionBinaryLength + SuccessFlagBinaryLength, ChecksumBinaryLength);
            Array.Copy(battleBinary, 0, binaryPool, VersionBinaryLength + SuccessFlagBinaryLength + ChecksumBinaryLength, battleBinary.Length);
        }

        binarySize = VersionBinaryLength + battleBinary.Length + ChecksumBinaryLength + SuccessFlagBinaryLength;
        return binaryPool;
    }

    private static byte[] GetSuccessFlagBinary(bool isSuccess)
    {
        var result = BitConverter.GetBytes(isSuccess);
        if (!BitConverter.IsLittleEndian)
            ReverseByteArray(result);

        return result;
    }

    private static byte[] GetBattleBinaryVersionBinary()
    {
        var result = BitConverter.GetBytes(BattleProgressDataDefinition.kTurnBattleSnapshotVersion);
        if (!BitConverter.IsLittleEndian)
            ReverseByteArray(result);

        return result;
    }

    private static byte[] GetChecksumBinary(byte[] binary, int startIndex, int length)
    {
        var sum = binary.Skip(startIndex).Take(length).Sum(x => x);

        var result = BitConverter.GetBytes(sum);
        if (!BitConverter.IsLittleEndian)
            ReverseByteArray(result);

        return result;
    }

    private static void ReverseByteArray(byte[] binary)
    {
        Array.Reverse(binary);
    }

    private static void FlushBinary(byte[] binary)
    {
        Array.Clear(binary, 0, binary.Length);
    }
}
