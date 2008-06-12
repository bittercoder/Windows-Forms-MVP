using DevDefined.Winforms.Framework.Docking;

namespace DevDefined.Winforms.Framework.Content
{
    public interface IOutputView : IView
    {
        void SetPresenter(IOutputPresenter presenter);
    }
}