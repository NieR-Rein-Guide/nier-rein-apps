using NierReincarnation.Core.Art.Framework.ApiNetwork.Data;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Mediator.Model;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Parameter;

public sealed class UserParameter : ParameterBase
{
    private readonly SynchronizationContext _context;
    private readonly string _uuid;

    private string Signature { get; set; }

    public long UserId { get; set; }

    public UserParameter()
    {
        _context = SynchronizationContext.Current;
        UserId = ApiSystem.Instance.DataStore.GetLong(Key.UserId);
    }

    public void SetUserData(UserRegisterData registerData)
    {
        UserId = registerData.UserId;
        Signature = registerData.Signature;

        ApiSystem.Instance.DataStore.Set(Key.UserId, registerData.UserId);
    }
}
