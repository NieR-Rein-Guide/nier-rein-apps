using System;

namespace NierReincarnation.Core.Octo.Loader
{
    abstract class BaseExecutor : IExecutor
    {
        public bool SetTopPriority(string name, bool immediateExecute = false)
        {
            throw new NotImplementedException();
        }

        public void AbortAll()
        {
            throw new NotImplementedException();
        }
    }
}
