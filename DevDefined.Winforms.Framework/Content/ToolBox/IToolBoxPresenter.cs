using DevDefined.Winforms.Framework.Docking;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Content.ToolBox
{
    [DockInPosition(State = DockState.DockLeft)]
    public interface IToolBoxPresenter : IPresenter
    {
    }
}