using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Property
{
    // Art.Framework.ApiNetwork.Api.Parameter.Property.ResponseProperty
    class ResponseProperty
    {
        private bool _isHandledBaseResponse; // 0x10
        private bool _isHandledSuccessResponse; // 0x11
        private ErrorControlType _errorControlType; // 0x14

        // Properties
        public bool IsHandledBaseResponse
        {
            set => _isHandledBaseResponse = value;
        }
        public bool IsHandledSuccessResponse
        {
            set => _isHandledSuccessResponse = value;
        }
        public ErrorControlType ErrorControlType
        {
            set => _errorControlType = value;
        }
    }
}
