using DevDefined.Winforms.Framework.Docking;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Content
{
    [DockInPosition(State = DockState.DockBottom, HideAfterPositioned = true)]
    public interface IOutputPresenter : IPresenter
    {
    }
}