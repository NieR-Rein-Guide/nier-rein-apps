using System.Threading;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Data;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Mediator.Model;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter
{
    // Art.Framework.ApiNetwork.Parameter.UserParameter
    class UserParameter : ParameterBase
    {
        private readonly SynchronizationContext _context; // 0x10
        private string _signature; // 0x18
        private string _uuid; // 0x20

        private string Signature
        {
            set => _signature = value;
        }

        // 0x28
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
}
