using System.Threading.Tasks;

namespace NierReincarnation.Core.Dark.Networking.DataSource
{
    // Dark.Networking.DataSource.IDataSource
    interface IDataSource
    {
        Task RequestAsync(object request, bool isInterception);
    }
}
