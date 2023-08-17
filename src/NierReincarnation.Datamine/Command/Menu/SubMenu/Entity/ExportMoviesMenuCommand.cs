using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportMoviesMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override async Task ExecuteAsync()
    {
        var movies = await new FetchAllMoviesCommand().ExecuteAsync(new FetchAllMoviesCommandArg());

        foreach (var movieGroup in movies.GroupBy(x => x.Category))
        {
            Console.WriteLine($"{movieGroup.Key}".ToBold());

            foreach (var movie in movieGroup)
            {
                Console.WriteLine($"{movie.Name}");
            }

            Console.WriteLine();
        }
    }
}
