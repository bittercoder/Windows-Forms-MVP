using DevDefined.Winforms.Framework.Content.PropertyGrid;
using DevDefined.Winforms.Framework.Docking;

namespace DevDefined.Winforms.Framework.Content
{
    public interface IPropertyGridView : IView
    {
        void SetPresenter(IPropertyGridPresenter presenter);
    }
}