using System.Windows.Forms;
using DevDefined.Winforms.Framework.Docking;
using DevDefined.Winforms.Framework.Menus;

namespace DevDefined.Winforms.Framework.Content.ProjectExplorer
{
    public class ProjectExplorerPresenter : AbstractPresenter, IProjectExplorerPresenter
    {
        private readonly IMenuController _menuController;
        private readonly IProjectExplorerView _view;

        public ProjectExplorerPresenter(IProjectExplorerView view, IMenuController menuController)
            : base(view)
        {
            _menuController = menuController;
            _view = view;
            view.SetPresenter(this);

            IMenuRegistry toolBar = _menuController.GetMenuFor(typeof (IProjectExplorerPresenter));

            view.SetToolbar(toolBar);
        }

        #region IProjectExplorerPresenter Members

        public void RightClickNode()
        {
            IMenuRegistry registry = _menuController
                .GetMenuFor(typeof (TreeNode));

            _view.ShowContextMenu(registry);
        }

        #endregion
    }
}