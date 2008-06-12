using DevDefined.Winforms.Framework.Docking;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Content.ProjectExplorer
{
    [DockInPosition(State = DockState.DockRight)]
    public interface IProjectExplorerPresenter : IPresenter
    {
        void RightClickNode();
    }
}