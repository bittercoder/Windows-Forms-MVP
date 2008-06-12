using System.Linq;
using DevDefined.Winforms.Framework.Commands;
using DevDefined.Winforms.Framework.Menus;
using NUnit.Framework;

namespace DevDefined.Winforms.Framework.Tests.Menus
{
    [TestFixture]
    public class MenuManagerTests
    {
        [Test]
        public void CreateCommandMenuModel()
        {
            var registry = new MenuRegistry();
            registry.AddCommand(new ExitApplicationCommand(),
                                new MainMenuAttribute {AfterMenuItem = "MostRecentlyUsedItems"});

            var model = (CommandMenuModel) registry.FindModel("ApplicationExit");

            Assert.AreEqual("MostRecentlyUsedItems", model.After);
            Assert.AreEqual(0, model.Children.Count());
            Assert.AreEqual("ApplicationExit", model.Name);
        }

        [Test]
        public void CreateMultipleContainingFolders()
        {
            var registry = new MenuRegistry();
            registry.AddCommand(new ExitApplicationCommand(), new MainMenuAttribute {Path = "/Addins/My Addin/"});

            var addinsModel = registry.FindModel("Addins") as FolderMenuModel;
            Assert.IsNotNull(addinsModel);

            var myAddinModel = registry.FindModel("Addins/My Addin") as FolderMenuModel;
            Assert.IsNotNull(myAddinModel);
        }

        [Test]
        public void CreateSingleContainingFolder()
        {
            var registry = new MenuRegistry();
            registry.AddCommand(new ExitApplicationCommand(), new MainMenuAttribute {Path = "File"});

            var model = registry.FindModel("File") as FolderMenuModel;
            Assert.IsNotNull(model);
        }

        [Test]
        public void CreateTopLevelMenuItem()
        {
            var registry = new MenuRegistry();
            registry.AddCommand(new ExitApplicationCommand(), new MainMenuAttribute());

            var model = registry.FindModel("ApplicationExit") as CommandMenuModel;
            Assert.IsNotNull(model);
        }
    }
}