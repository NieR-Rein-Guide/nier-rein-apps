using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllFateBoardsCommand : AbstractDbQueryCommand<FetchAllFateBoardsCommandArg, List<FateBoard>>
{
    public override async Task<List<FateBoard>> ExecuteAsync(FetchAllFateBoardsCommandArg arg)
    {
        List<FateBoard> fateBoards = new();

        foreach (var darkEventChapter in MasterDb.EntityMEventQuestChapterTable.All
            .Where(x => x.EventQuestType == EventQuestType.LABYRINTH)
            .OrderBy(x => x.StartDatetime))
        {
            var fateBoard = await new FetchFateBoardCommand().ExecuteAsync(new FetchFateBoardCommandArg
            {
                Entity = darkEventChapter,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            });

            if (fateBoard != null)
            {
                fateBoards.Add(fateBoard);
            }
        }

        return fateBoards;
    }
}

public class FetchAllFateBoardsCommandArg : AbstractCommandWithDatesArg
{
}
