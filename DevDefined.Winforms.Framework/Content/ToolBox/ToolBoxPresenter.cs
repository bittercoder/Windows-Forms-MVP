using DevDefined.Winforms.Framework.Docking;

namespace DevDefined.Winforms.Framework.Content.ToolBox
{
    public class ToolBoxPresenter : AbstractPresenter, IToolBoxPresenter
    {
        public ToolBoxPresenter(IToolBoxView view)
            : base(view)
        {
            view.SetPresenter(this);
        }
    }
}