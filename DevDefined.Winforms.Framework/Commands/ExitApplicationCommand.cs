using System;
using System.Windows.Forms;
using DevDefined.Winforms.Framework.Menus;

namespace DevDefined.Winforms.Framework.Commands
{
    [MainMenu(Path = "File", AfterMenuItem = "MostRecentlyUsed", SeperatorAbove = true)]    
    public class ExitApplicationCommand : AbstractCommand
    {
        public override string Text
        {
            get { return "Exit"; }
        }

        public override string Name
        {
            get { return "ApplicationExit"; }
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}