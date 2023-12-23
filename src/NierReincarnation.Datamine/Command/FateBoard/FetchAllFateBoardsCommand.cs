using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllFateBoardsCommand : AbstractDbQueryCommand<FetchAllFateBoardsCommandArg, List<FateBoard>>
{
    public override async Task<List<FateBoard>> ExecuteAsync(FetchAllFateBoardsCommandArg arg)
    {
        List<FateBoard> fateBoards = [];

        foreach (var darkEventChapter in MasterDb.EntityMEventQuestChapterTable.All
            .Where(x => x.EventQuestType == EventQuestType.LABYRINTH)
            .OrderBy(x => x.StartDatetime))
        {
            var fateBoard = await new FetchFateBoardCommand().ExecuteAsync(new FetchFateBoardCommandArg
            {
                Entity = darkEventChapter,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate,
                OnlyLastStage = arg.OnlyLastStage
            });

            if (fateBoard == null) continue;
            if (!arg.IncludeEmptyBoards && fateBoard.Seasons.Count == 0) continue;

            fateBoards.Add(fateBoard);
        }

        return fateBoards;
    }
}

public class FetchAllFateBoardsCommandArg : AbstractCommandWithDatesArg
{
    public bool IncludeEmptyBoards { get; init; }

    public bool OnlyLastStage { get; init; }
}
