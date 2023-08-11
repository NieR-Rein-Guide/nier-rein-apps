using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;

public abstract class ResponseParameterBase
{
    protected CommonResponse CommonResponse;

    public ScreenTransitionType ScreenTransitionType => CommonResponse.ScreenTransitionType;

    public string MessageId => CommonResponse.MessageCode;

    public CommonResponse GetCommon() => GetCommon<CommonResponse>();

    public T GetCommon<T>() => (T)Convert.ChangeType(CommonResponse, typeof(T));

    public abstract bool IsResponseNullOrEmpty();
}
