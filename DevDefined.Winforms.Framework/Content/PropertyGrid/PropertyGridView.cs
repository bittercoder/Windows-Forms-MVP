using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Content.PropertyGrid
{
    public partial class PropertyGridView : DockContent, IPropertyGridView
    {
        private IPropertyGridPresenter _presenter;

        public PropertyGridView()
        {
            InitializeComponent();
        }

        #region IPropertyGridView Members

        public void SetPresenter(IPropertyGridPresenter presenter)
        {
            _presenter = presenter;
        }

        #endregion
    }
}