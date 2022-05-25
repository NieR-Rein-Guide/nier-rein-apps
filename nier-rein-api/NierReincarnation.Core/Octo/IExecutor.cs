namespace NierReincarnation.Core.Octo
{
    interface IExecutor
    {
        // RVA: -1 Offset: -1 Slot: 0
        bool SetTopPriority(string name, bool immediateExecute = false);

        // RVA: -1 Offset: -1 Slot: 1
        void AbortAll();
    }
}
