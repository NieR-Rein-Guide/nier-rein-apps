namespace NierReincarnation.Core.Octo.Data
{
    abstract class SecureSerializableDatabase<T> : SecureFile // TypeDefIndex: 6572
    {
        // Fields
        private static readonly string Tag = "Octo/Data/DataUtils/SecureSerializableDatabase"; // 0x0

        // 0x20
        public T Data { get; set; }

        public SecureSerializableDatabase(string path, AESCrypt crypt) : base(path, crypt) { }

        protected abstract T Deserialize(byte[] bytes);

        public void Deserialize()
        {
            var loadedFile = Load();
            if (loadedFile == null || loadedFile.Length <= 0)
                return;

            Data = Deserialize(loadedFile);
        }
    }
}
