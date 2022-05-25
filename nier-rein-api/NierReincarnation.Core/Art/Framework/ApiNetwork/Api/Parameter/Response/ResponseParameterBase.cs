using System;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response
{
    // Art.Framework.ApiNetwork.Api.Parameter.Response.ResponseParameterBase
    abstract class ResponseParameterBase
    {
        protected CommonResponse CommonResponse; // 0x10

        // Properties
        public int ScreenTransitionType => CommonResponse.screenTransitionType;
        public string MessageId => CommonResponse.messageCode;

        public CommonResponse GetCommon()
        {
            return GetCommon<CommonResponse>();
        }

        public T GetCommon<T>()
        {
            return (T)Convert.ChangeType(CommonResponse, typeof(T));
        }

        public abstract bool IsResponseNullOrEmpty();
    }
}
