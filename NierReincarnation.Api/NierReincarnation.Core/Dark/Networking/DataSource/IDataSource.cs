namespace NierReincarnation.Core.Dark.Networking.DataSource;

public interface IDataSource
{
    Task RequestAsync(object request, bool isInterception);
}
