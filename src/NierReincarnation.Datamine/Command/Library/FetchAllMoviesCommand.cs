using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllMoviesCommand : AbstractDbQueryCommand<FetchAllMoviesCommandArg, List<Movie>>
{
    public override Task<List<Movie>> ExecuteAsync(FetchAllMoviesCommandArg arg)
    {
        List<Movie> movies = [];

        foreach (var darkLibraryMovie in MasterDb.EntityMLibraryMovieTable.All)
        {
            var darkLibraryMovieCategory = MasterDb.EntityMLibraryMovieCategoryTable.All.FirstOrDefault(x => x.LibraryMovieCategoryId == darkLibraryMovie.LibraryMovieCategoryId);
            var darkLibraryMovieUnlockCondition = MasterDb.EntityMLibraryMovieUnlockConditionTable.FindByLibraryMovieUnlockConditionId(darkLibraryMovie.LibraryMovieUnlockConditionId);
            var darkTitleFlowMovie = MasterDb.EntityMTitleFlowMovieTable.All.FirstOrDefault(x => x.MovieId == darkLibraryMovie.MovieId);
            var darkEvaluateCondition = MasterDb.EntityMEvaluateConditionTable.FindByEvaluateConditionId(darkLibraryMovie.LibraryMovieUnlockEvaluateConditionId);

            string movieNameStr = $"movie.title.name.{darkLibraryMovie.TitleLibraryTextId}".Localize();
            string movieCategoryStr = $"quest.main.season_title.{darkLibraryMovie.LibraryMovieCategoryId}".Localize();

            //Console.WriteLine("Name: " + movieNameStr);
            //Console.WriteLine("Category: " + (!string.IsNullOrEmpty(movieCategoryStr) ? movieCategoryStr : "Other"));
            //Console.WriteLine("EvaluateId: " + darkLibraryMovie.LibraryMovieUnlockEvaluateConditionId);
            //Console.WriteLine("ConditionId: " + darkLibraryMovie.LibraryMovieUnlockConditionId);

            //if (darkLibraryMovieUnlockCondition != null)
            //{
            //    Console.WriteLine("ConditionType: " + darkLibraryMovieUnlockCondition.UnlockConditionType);
            //    Console.WriteLine("ConditionValue: " + darkLibraryMovieUnlockCondition.ConditionValue);
            //}

            //Console.WriteLine();

            if (string.IsNullOrEmpty(movieNameStr)) continue;

            movies.Add(new Movie
            {
                Name = movieNameStr,
                Category = !string.IsNullOrEmpty(movieCategoryStr) ? movieCategoryStr : "Other"
            });
        }

        return Task.FromResult(movies);
    }
}

public class FetchAllMoviesCommandArg
{
}
