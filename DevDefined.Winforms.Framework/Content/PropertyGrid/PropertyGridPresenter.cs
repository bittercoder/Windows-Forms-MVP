using DevDefined.Winforms.Framework.Docking;

namespace DevDefined.Winforms.Framework.Content.PropertyGrid
{
    public class PropertyGridPresenter : AbstractPresenter, IPropertyGridPresenter
    {
        public PropertyGridPresenter(IPropertyGridView view)
            : base(view)
        {
            view.SetPresenter(this);
        }
    }
}