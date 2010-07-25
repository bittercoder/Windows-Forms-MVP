using System.Linq;
using DevDefined.Winforms.Framework.Commands;
using DevDefined.Winforms.Framework.Menus;
using Xunit;

namespace DevDefined.Winforms.Framework.Tests.Menus
{
    public class MenuManagerTests
    {
        [Fact]
        public void CreateCommandMenuModel()
        {
            var registry = new MenuRegistry();
            registry.AddCommand(new ExitApplicationCommand(),
                                new MainMenuAttribute {AfterMenuItem = "MostRecentlyUsedItems"});

            var model = (CommandMenuModel) registry.FindModel("ApplicationExit");

            Assert.Equal("MostRecentlyUsedItems", model.After);
            Assert.Equal(0, model.Children.Count());
            Assert.Equal("ApplicationExit", model.Name);
        }

        [Fact]
        public void CreateMultipleContainingFolders()
        {
            var registry = new MenuRegistry();
            registry.AddCommand(new ExitApplicationCommand(), new MainMenuAttribute {Path = "/Addins/My Addin/"});

            var addinsModel = registry.FindModel("Addins") as FolderMenuModel;
            Assert.NotNull(addinsModel);

            var myAddinModel = registry.FindModel("Addins/My Addin") as FolderMenuModel;
            Assert.NotNull(myAddinModel);
        }

        [Fact]
        public void CreateSingleContainingFolder()
        {
            var registry = new MenuRegistry();
            registry.AddCommand(new ExitApplicationCommand(), new MainMenuAttribute {Path = "File"});

            var model = registry.FindModel("File") as FolderMenuModel;
            Assert.NotNull(model);
        }

        [Fact]
        public void CreateTopLevelMenuItem()
        {
            var registry = new MenuRegistry();
            registry.AddCommand(new ExitApplicationCommand(), new MainMenuAttribute());

            var model = registry.FindModel("ApplicationExit") as CommandMenuModel;
            Assert.NotNull(model);
        }
    }
}