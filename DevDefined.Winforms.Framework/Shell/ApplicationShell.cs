using System;
using System.Windows.Forms;
using Castle.MicroKernel;
using DevDefined.Winforms.Framework.Container;
using DevDefined.Winforms.Framework.EventPublisher;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Shell
{
    public partial class ApplicationShell : Form, IApplicationShell
    {
        private readonly IEventPublisher _publisher;

        public ApplicationShell(IKernel kernel, IEventPublisher publisher)
        {
            InitializeComponent();
            RegisterServices(kernel);
            _publisher = publisher;
        }

        #region IApplicationShell Members

        public string CurrentActivity
        {
            get { return statusLabel.Text; }
            set { statusLabel.Text = value; }
        }

        #endregion

        private void RegisterServices(IKernel kernel)
        {
            kernel.AddComponentInstance<IApplicationShell>(this);
            kernel.AddComponentInstance<DockPanel>(dockPanel1);
            kernel.AddComponentInstance(CoreModule.MainMenuToolStripKey, topMenu);
        }

        private void ApplicationShell_Load(object sender, EventArgs e)
        {
            _publisher.PublishEvent(new ApplicationStartedSubject());
        }
    }
}