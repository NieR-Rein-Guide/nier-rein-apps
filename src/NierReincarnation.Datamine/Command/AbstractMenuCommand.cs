using DustInTheWind.ConsoleTools.Controls.Menus;
using DustInTheWind.ConsoleTools.Controls.Musical;
using DustInTheWind.ConsoleTools.Controls.Spinners;
using NierReincarnation.Api;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public abstract class AbstractSimpleMenuCommand : ICommand
{
    public virtual bool IsActive => true;

    public virtual int Revision { get; init; }

    public virtual bool Reset { get; init; }

    public virtual bool Login { get; init; } = true;

    public virtual bool UseApi { get; init; } = true;

    public virtual bool UseLocalizations { get; init; } = true;

    protected static DarkMasterMemoryDatabase MasterDb => DatabaseDefine.Master;

    private static bool IsLocalizationInitialized => LocalizationExtensions.Localizations?.Count > 0;

    public abstract void Execute();

    protected async Task Setup()
    {
        try
        {
            if (Reset)
            {
                NierReincarnationApp.ResetApplication();
            }

            if (UseApi)
            {
                await InitializeNierReinApi(Revision, Login);
            }

            if (UseLocalizations && !IsLocalizationInitialized)
            {
                await InitializeLocalizations();
            }
        }
        finally
        {
            Console.WriteLine();
        }
    }

    private static async Task InitializeNierReinApi(int revision = 0, bool login = true)
    {
        await NierReincarnationApp.InitializeApplicationAsync(new ApplicationInitArguments(login, login, true, revision));
    }

    private static async Task InitializeLocalizations()
    {
        await NierReincarnationApp.LoadLocalizations(Application.SystemLanguage);
    }
}

public abstract class AbstractMenuCommand : AbstractSimpleMenuCommand, IAsyncCommand
{
    public override void Execute()
    {
        using (Spinner spinner = MenuExtensions.GetSpinner())
        {
            try
            {
                spinner.Display();
                Setup().GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                spinner.Close();
                throw;
            }
        }

        ExecuteAsync().GetAwaiter().GetResult();
    }

    public abstract Task ExecuteAsync();
}

public abstract class AbstractMenuCommand<T> : AbstractSimpleMenuCommand, IAsyncCommand<T>
{
    private readonly T _Arg;

    protected AbstractMenuCommand(T arg)
    {
        _Arg = arg;
    }

    public override void Execute()
    {
        using (Spinner spinner = MenuExtensions.GetSpinner())
        {
            try
            {
                spinner.Display();
                Setup().GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                spinner.Close();
                throw;
            }
        }

        ExecuteAsync(_Arg).GetAwaiter().GetResult();
    }

    public abstract Task ExecuteAsync(T arg);
}

public abstract class AbstractWatcherMenuCommand<T, R> : AbstractSimpleMenuCommand, IAsyncCommand<T, R> where R : WatcherResult
{
    private readonly T _Arg;

    protected AbstractWatcherMenuCommand(T arg)
    {
        _Arg = arg;
    }

    public virtual ConsoleKey StopKey => ConsoleKey.Escape;

    public virtual MusicalNote NotificationSound => MusicalNote.Fd6;

    public virtual int NotificationDuration => 5000;

    public virtual int Interval => 25000;

    public string TimeNow => DateTimeOffset.Now.ToString("H:mm:ss");

    public override void Execute()
    {
        bool @break = false;
        Setup().GetAwaiter().GetResult();
        do
        {
            while (!Console.KeyAvailable)
            {
                if (@break)
                {
                    Sound.Play(NotificationSound, NotificationDuration);
                    break;
                }

                @break = ExecuteAsync(_Arg).GetAwaiter().GetResult().Success;

                Task.Delay(Interval).GetAwaiter().GetResult();
                Setup().GetAwaiter().GetResult();
            }
            break;
        }
        while (Console.ReadKey(true).Key != StopKey);
    }

    public abstract Task<R> ExecuteAsync(T arg);

    protected void WriteLineWithTimestamp(string text)
    {
        Console.WriteLine($"{TimeNow}: {text}");
    }
}

public class WatcherResult
{
    public WatcherResult(bool success)
    {
        Success = success;
    }

    public bool Success { get; init; }
}
