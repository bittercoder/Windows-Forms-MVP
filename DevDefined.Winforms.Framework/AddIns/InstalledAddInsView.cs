using System.Windows.Forms;

namespace DevDefined.Winforms.Framework.AddIns
{
    public partial class InstalledAddInsView : Form, IInstalledAddInsView
    {
        private IInstalledAddInsPresenter _presenter;

        public InstalledAddInsView()
        {
            InitializeComponent();
        }

        #region IInstalledAddInsView Members

        public void SetPresenter(IInstalledAddInsPresenter presenter)
        {
            _presenter = presenter;
        }

        #endregion
    }
}