using System.Windows.Forms;
using DevDefined.Winforms.Framework.Content.ProjectExplorer;
using DevDefined.Winforms.Framework.Docking;
using DevDefined.Winforms.Framework.Menus;

namespace DevDefined.Winforms.Framework.Content
{
    public interface IProjectExplorerView : IView
    {
        TreeNode SelectedNode { get; }
        void SetPresenter(IProjectExplorerPresenter presenter);
        void ShowContextMenu(IMenuRegistry registry);
        void SetToolbar(IMenuRegistry registry);
    }
}