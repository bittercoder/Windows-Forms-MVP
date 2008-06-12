using System;
using System.Windows.Forms;
using DevDefined.Winforms.Framework.Container;
using DevDefined.Winforms.Framework.Shell;

namespace DevDefined.Winforms.TestHost
{
    internal static class Program
    {
        private static readonly WinformsContainer _container = new WinformsContainer(new CoreModule());

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((Form) _container.Resolve<IApplicationShell>());
        }
    }
}