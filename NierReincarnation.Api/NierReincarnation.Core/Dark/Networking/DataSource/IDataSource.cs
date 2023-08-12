namespace NierReincarnation.Core.Dark.Networking.DataSource;

// Dark.Networking.DataSource.IDataSource
internal interface IDataSource
{
    Task RequestAsync(object request, bool isInterception);
}
