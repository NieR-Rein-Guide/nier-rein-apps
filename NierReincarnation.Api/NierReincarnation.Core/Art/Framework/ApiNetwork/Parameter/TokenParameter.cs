namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Parameter;

public class TokenParameter : ParameterBase
{
    private string _token;

    public void UpdateToken(string token)
    {
        if (!string.IsNullOrEmpty(token))
        {
            _token = token;
        }
    }
}
