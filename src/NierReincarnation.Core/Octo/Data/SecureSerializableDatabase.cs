namespace NierReincarnation.Core.Octo.Data;

internal abstract class SecureSerializableDatabase<T> : SecureFile
{
    private const string Tag = "Octo/Data/DataUtils/SecureSerializableDatabase";

    public T Data { get; set; }

    public SecureSerializableDatabase(string path, AESCrypt crypt) : base(path, crypt) { }

    protected abstract T Deserialize(byte[] bytes);

    public void Deserialize()
    {
        var loadedFile = Load();
        if (loadedFile == null || loadedFile.Length == 0) return;

        Data = Deserialize(loadedFile);
    }
}
