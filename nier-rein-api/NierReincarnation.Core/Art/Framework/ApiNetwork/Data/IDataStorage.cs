namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Data
{
    // Art.Framework.ApiNetwork.Data.IDataStorage
    interface IDataStorage
    {
        string GetFilePath();

        T Load<T>(string filePath) where T : new();

        bool Save<T>(string filePath, T value);
	}
}
