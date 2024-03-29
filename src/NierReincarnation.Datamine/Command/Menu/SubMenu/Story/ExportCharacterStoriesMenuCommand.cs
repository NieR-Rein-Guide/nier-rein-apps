﻿using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCharacterStoriesMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        Console.Clear();
        BuildStoriesMenu().Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildStoriesMenu()
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu();
        List<TextMenuItem> menuItems =
        [
            new TextMenuItem
            {
                Id = "0",
                Text = "Go Back",
                Command = new ExportStoriesMenuCommand()
            }
        ];

        int i = 1;
        foreach (var darkEventQuestChapter in MasterDb.EntityMEventQuestChapterTable.All.Where(x => x.EventQuestType == EventQuestType.CHARACTER).OrderBy(x => x.SortOrder))
        {
            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = CalculatorCharacter.GetCharacterName(CalculatorQuest.GetChapterCharacterId(darkEventQuestChapter.EventQuestChapterId)),
                Command = new ExportCharacterStoryMenuCommand(new ExportCharacterStoryMenuCommandArg { EventQuestChapterId = darkEventQuestChapter.EventQuestChapterId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
