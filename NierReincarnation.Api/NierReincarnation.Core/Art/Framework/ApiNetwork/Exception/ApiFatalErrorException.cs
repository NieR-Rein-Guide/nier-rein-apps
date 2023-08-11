using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Exception;

public class ApiFatalErrorException : ApiErrorException
{
    public ApiFatalErrorException(ResponseParameterBase response) : base(response)
    {
    }
}
