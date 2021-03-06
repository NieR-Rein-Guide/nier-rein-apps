namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter
{
    // Art.Framework.ApiNetwork.Parameter.TokenParameter
    class TokenParameter : ParameterBase
    {
        private string _token; // 0x10

        public void UpdateToken(string token)
        {
            if (!string.IsNullOrEmpty(token))
                _token = token;
        }
    }
}
