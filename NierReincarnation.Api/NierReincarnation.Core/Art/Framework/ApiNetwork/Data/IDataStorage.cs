namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Data;

public interface IDataStorage
{
    string GetFilePath();

    T Load<T>(string filePath) where T : new();

    bool Save<T>(string filePath, T value);
}
