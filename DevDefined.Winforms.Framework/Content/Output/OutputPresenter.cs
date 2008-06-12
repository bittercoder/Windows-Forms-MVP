using DevDefined.Winforms.Framework.Docking;

namespace DevDefined.Winforms.Framework.Content
{
    public class OutputPresenter : AbstractPresenter, IOutputPresenter
    {
        public OutputPresenter(IOutputView view)
            : base(view)
        {
            view.SetPresenter(this);
        }
    }
}