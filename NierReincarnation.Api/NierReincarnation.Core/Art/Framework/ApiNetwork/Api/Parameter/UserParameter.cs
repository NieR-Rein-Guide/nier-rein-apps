using System.Threading;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Data;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Mediator.Model;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter;

// Art.Framework.ApiNetwork.Parameter.UserParameter
class UserParameter : ParameterBase
{
    private readonly SynchronizationContext _context;
    private string _signature;
    private string _uuid;

    private string Signature
    {
        set => _signature = value;
    }

   
    public long UserId { get; set; }

    // Methods

    public UserParameter()
    {
        _context = SynchronizationContext.Current;
        UserId = ApiSystem.Instance.DataStore.GetLong(Key.UserId);
    }

    // RVA: 0x2B78FB0 Offset: 0x2B78FB0 VA: 0x2B78FB0
    public void SetUserData(UserRegisterData registerData)
    {
        UserId = registerData.UserId;
        _signature = registerData.Signature;

        ApiSystem.Instance.DataStore.Set(Key.UserId, registerData.UserId);
    }
}
