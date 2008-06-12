using System.Drawing;
using System.Windows.Forms;
using DevDefined.Winforms.Framework.Images;
using DevDefined.Winforms.Framework.Menus;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Content.ProjectExplorer
{
    public partial class ProjectExplorerView : DockContent, IProjectExplorerView
    {
        private Point _lastPoint;
        private IProjectExplorerPresenter _presenter;
        private ToolBarMenuPresenter _toolBarPresenter;

        public ProjectExplorerView()
        {
            InitializeComponent();
        }

        public IImageFactory ImageFactory { get; set; }

        #region IProjectExplorerView Members

        public void SetPresenter(IProjectExplorerPresenter presenter)
        {
            _presenter = presenter;
        }

        public TreeNode SelectedNode
        {
            get { return treeView1.SelectedNode; }
        }

        public void ShowContextMenu(IMenuRegistry registry)
        {
            var menu = new ContextMenuStrip();
            var presenter = new ToolStripMenuPresenter(menu, registry, ImageFactory);
            presenter.Populate();
            menu.Show(_lastPoint);
        }

        public void SetToolbar(IMenuRegistry registry)
        {
            _toolBarPresenter = new ToolBarMenuPresenter(toolStrip, registry, ImageFactory);
            _toolBarPresenter.Populate();
        }

        #endregion

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var clickPoint = new Point(e.X, e.Y);
            _lastPoint = PointToScreen(clickPoint);

            if (e.Button == MouseButtons.Right)
            {
                _presenter.RightClickNode();
            }
        }
    }
}