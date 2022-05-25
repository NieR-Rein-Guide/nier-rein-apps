using System;
using System.Threading.Tasks;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    // Adam.Framework.Network.INetworkInterceptor
    public interface INetworkInterceptor
    {
        Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next);
    }
}
