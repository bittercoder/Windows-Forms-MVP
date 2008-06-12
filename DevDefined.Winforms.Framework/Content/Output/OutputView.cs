using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Content.Output
{
    public partial class OutputView : DockContent, IOutputView
    {
        private IOutputPresenter _presenter;

        public OutputView()
        {
            InitializeComponent();
        }

        #region IOutputView Members

        public void SetPresenter(IOutputPresenter presenter)
        {
            _presenter = presenter;
        }

        #endregion
    }
}