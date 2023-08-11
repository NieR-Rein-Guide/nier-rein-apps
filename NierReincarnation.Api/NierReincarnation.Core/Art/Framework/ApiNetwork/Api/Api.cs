using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Property;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api
{
    public abstract class Api
    {
        protected ApiProperty _property;

        protected ResponseProperty _responseProperty;

        protected RequestProperty _requestProperty;

        public abstract T GetResponseParameter<T>();

        public T GetApiProperty<T>() => (T)Convert.ChangeType(_property, typeof(T));

        public T GetResponseProperty<T>() => (T)Convert.ChangeType(_responseProperty, typeof(T));

        public T GetRequestProperty<T>() => (T)Convert.ChangeType(_requestProperty, typeof(T));

        internal abstract void Retry(bool interrupt = false);

        internal abstract void TrySetResultCompletionTask();

        internal abstract void TrySetExceptionCompletionTask<T>(T exception);

        internal abstract void TrySetCanceledCompletionTask();
    }
}
