using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Property;

public class ResponseProperty
{
    private bool _isHandledBaseResponse;
    private bool _isHandledSuccessResponse;
    private ErrorControlType _errorControlType;

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
