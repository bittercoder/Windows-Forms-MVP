using System.Windows.Forms;
using DevDefined.Winforms.Framework.Content.ProjectExplorer;
using DevDefined.Winforms.Framework.Images;
using DevDefined.Winforms.Framework.Menus;

namespace DevDefined.Winforms.Framework.Commands
{
    [ContextMenu(TargetType = typeof(IProjectExplorerPresenter), Image = CoreImages.DeleteHS)]
    [ContextMenu(TargetType = typeof(TreeNode))]    
    public class DeleteNodeCommand : AbstractCommand
    {
        public override string Text
        {
            get { return "Delete"; }
        }

        public override string Name
        {
            get { return "ProjectExplorerDelete"; }
        }

        public override void Execute()
        {
            MessageBox.Show("Delete was clicked");
        }
    }
}