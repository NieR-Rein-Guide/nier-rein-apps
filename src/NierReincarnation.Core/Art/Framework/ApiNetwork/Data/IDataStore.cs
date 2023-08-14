namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Data;

public interface IDataStore
{
    string Get(Key key);

    long GetLong(Key key);

    void Set(Key key, string value);

    void Set(Key key, long value);
}
