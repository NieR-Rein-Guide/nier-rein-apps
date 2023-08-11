using System;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Property;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api
{
    // Art.Framework.ApiNetwork.Api.Api
    public abstract class Api
    {
        // 0x10
        protected ApiProperty _property;
        // 0x18
        protected ResponseProperty _responseProperty;
        // 0x20
        protected RequestProperty _requestProperty;

        public abstract T GetResponseParameter<T>();

        public T GetApiProperty<T>()
        {
            return (T)Convert.ChangeType(_property, typeof(T));
        }

        public T GetResponseProperty<T>()
        {
            return (T)Convert.ChangeType(_responseProperty, typeof(T));
        }

        public T GetRequestProperty<T>()
        {
            return (T)Convert.ChangeType(_requestProperty, typeof(T));
        }

        internal abstract void Retry(bool interrupt = false);

        internal abstract void TrySetResultCompletionTask();

        internal abstract void TrySetExceptionCompletionTask<T>(T exception);
        /* GenericInstMethod :
        |
        |-RVA: -1 Offset: -1
        |-Api.TrySetExceptionCompletionTask<object>
        */

        internal abstract void TrySetCanceledCompletionTask();
	}
}
