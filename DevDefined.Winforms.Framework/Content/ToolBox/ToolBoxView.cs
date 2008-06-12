using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Content.ToolBox
{
    public partial class ToolBoxView : DockContent, IToolBoxView
    {
        private IToolBoxPresenter _presenter;

        public ToolBoxView()
        {
            InitializeComponent();
        }

        #region IToolBoxView Members

        public void SetPresenter(IToolBoxPresenter presenter)
        {
            _presenter = presenter;
        }

        #endregion
    }
}