namespace NierReincarnation.Core.Octo;

public interface IExecutor
{
    bool SetTopPriority(string name, bool immediateExecute = false);

    void AbortAll();
}
