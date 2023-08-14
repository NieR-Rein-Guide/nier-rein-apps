namespace NierReincarnation.Core.Octo.Loader;

internal abstract class BaseExecutor : IExecutor
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
