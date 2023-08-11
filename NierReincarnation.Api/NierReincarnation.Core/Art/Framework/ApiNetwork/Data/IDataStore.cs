namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Data
{
    // Art.Framework.ApiNetwork.Data.IDataStore
    public interface IDataStore
    {
        string Get(Key key);

        long GetLong(Key key);

        void Set(Key key, string value);

        void Set(Key key, long value);
	}
}
